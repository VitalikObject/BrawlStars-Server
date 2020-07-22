using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using Colorful;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client
{
    class UseGadgetInRoomMessage : PiranhaMessage
    {
        public UseGadgetInRoomMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public override void Decode()
        {
            Resources.UseGadget = Reader.ReadBoolean();
        }
        public override async void Process()
        {
            await new Gameroom_Data(Device).SendAsync();
        }
    }
}
