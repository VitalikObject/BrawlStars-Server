using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using Colorful;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client
{
    class ClientActionMessage : PiranhaMessage
    {
        public ClientActionMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        private int Unk { get; set; }
        public override void Decode()
        {
            Unk = Reader.ReadVInt();
        }
        public override async void Process()
        {
            if(Unk == 4)
            {
                await new LoginFailedMessage(Device)
                {
                    Reason =
                                "Not implemented yet"
                }.SendAsync();
            }
        }
    }
}
