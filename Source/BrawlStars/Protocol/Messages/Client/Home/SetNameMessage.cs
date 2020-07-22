using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using DotNetty.Buffers;
using BrawlStars.Protocol.Messages.Server.Home;
using BrawlStars.Utilities.Netty;

namespace BrawlStars.Protocol.Messages.Client.Home
{
    class SetNameMessage : PiranhaMessage
    {
        public SetNameMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public override void Decode()
        {
            Resources.Name = Reader.ReadScString();
        }
        public override async void Process()
        {
            await new SetNameServer(Device).SendAsync();
        }
    }
}
