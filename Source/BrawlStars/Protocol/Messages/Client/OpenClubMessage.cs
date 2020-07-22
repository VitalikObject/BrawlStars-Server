using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client
{
    class OpenClubMessage : PiranhaMessage
    {
        public OpenClubMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public override void Decode()
        {
        }
        public override async void Process()
        {
            await new ClubServerMessage(Device).SendAsync();
        }
    }
}
