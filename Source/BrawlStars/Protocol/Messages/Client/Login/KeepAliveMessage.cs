using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client.Login
{
    public class KeepAliveMessage : PiranhaMessage
    {
        public KeepAliveMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public override async void Process()
        {
            await new KeepAliveOkMessage(Device).SendAsync();
        }
    }
}