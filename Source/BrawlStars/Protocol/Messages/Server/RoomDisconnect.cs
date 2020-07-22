using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;

namespace BrawlStars.Protocol.Messages.Server
{
    class RoomDisconnect : PiranhaMessage
    {
        public RoomDisconnect(Device device) : base(device)
        {
            Id = 24125;
        }

        public override async void Encode()
        {
            Writer.WriteHex("00000000");
        }
    }
}
