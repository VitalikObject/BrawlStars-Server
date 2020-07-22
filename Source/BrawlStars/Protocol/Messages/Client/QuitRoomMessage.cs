using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client
{
    class QuitRoomMessage : PiranhaMessage
    {
        public QuitRoomMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public override void Decode()
        {
        }
        public override async void Process()
        {
            Resources.Room = 0;
            Resources.RoomID = 0;
            await new RoomDisconnect(Device).SendAsync();
        }
    }
}
