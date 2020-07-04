using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client
{
    class ExitMessage : PiranhaMessage
    {
        public ExitMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }


        public override async void Process()
        {
            await new OwnHomeDataMessage(Device).SendAsync();
        }
    }
}
