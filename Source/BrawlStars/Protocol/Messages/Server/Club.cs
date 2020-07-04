using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;

namespace BrawlStars.Protocol.Messages.Server
{
    class Club : PiranhaMessage
    {
        public Club(Device device) : base(device)
        {

        }

        public override void Encode()
        {
            Writer.WriteHex("0100000000b0fd34000000000f616161616161616161616161616161080e01019f9a0c0000000000024652000000000000010000000036cf844f029f9a0c0000000000000f6b6b6b6b6b6b6b6b6b6b6b6b6b6b6ba40180fcd91a80838129ffff0000000000");
        }
    }
}
