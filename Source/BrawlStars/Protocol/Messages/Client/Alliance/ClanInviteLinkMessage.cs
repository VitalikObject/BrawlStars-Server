using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server.Alliance;
using DotNetty.Buffers;


namespace BrawlStars.Protocol.Messages.Client.Alliance
{
    class ClanInviteLinkMessage : PiranhaMessage
    {
        public ClanInviteLinkMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public override async void Process()
        {
            await new GenrateClanInviteLinkMessage(Device).SendAsync();
        }
    }
}

