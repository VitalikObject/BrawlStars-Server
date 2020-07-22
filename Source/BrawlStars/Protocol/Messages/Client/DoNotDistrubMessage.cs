using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
namespace BrawlStars.Protocol.Messages.Client
{
    class DoNotDistrubMessage : PiranhaMessage
    {
        public DoNotDistrubMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        private bool NotDistrub { get; set; }
        public override void Decode()
        {
            NotDistrub = Reader.ReadBoolean();
        }
        public override async void Process()
        {
            await new DoNotDistrubServer(Device) 
            {
                Distrub = NotDistrub
            }.SendAsync();
        }
    }
}
