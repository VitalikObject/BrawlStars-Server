using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
using System;

namespace BrawlStars.Protocol.Messages.Client
{
    class ChangeMapMessage : PiranhaMessage
    {
        public ChangeMapMessage(Device device, IByteBuffer buffer) : base(device, buffer)
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
            Resources.Map = MapId;
            await new Gameroom_Data(Device).SendAsync();
        }
    }
}
