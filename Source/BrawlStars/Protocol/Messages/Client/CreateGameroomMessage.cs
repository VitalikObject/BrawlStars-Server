using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using Colorful;
using DotNetty.Buffers;


namespace BrawlStars.Protocol.Messages.Client
{
    class CreateGameroomMessage : PiranhaMessage
    {
        public CreateGameroomMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public int MapId { get; set; }
        public override void Decode()
        {
            Reader.ReadVInt();
            MapId = Reader.ReadVInt();
        }
        public override async void Process()
        {
            switch(MapId)
            {
                case 1:
                    Resources.Map = 7;
                    break;
                case 2:
                    Resources.Map = 32;
                    break;
                case 3:
                    Resources.Map = 17;
                    break;
                case 4:
                    Resources.Map = 0;
                    break;
                case 5:
                    Resources.Map = 38;
                    break;
                case 6:
                    Resources.Map = 24;
                    break;
                case 7:
                    Resources.Map = 202;
                    break;
                case 8:
                    Resources.Map = 97;
                    break;
                case 9:
                    Resources.Map = 167;
                    break;
            }
            Resources.Room = 1;
            await new Gameroom_Data(Device).SendAsync();
        }
    }
}

