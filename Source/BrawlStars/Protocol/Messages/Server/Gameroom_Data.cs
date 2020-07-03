using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System.Text;

namespace BrawlStars.Protocol.Messages.Server
{
    class Gameroom_Data : PiranhaMessage
    {
        public Gameroom_Data(Device device) : base(device)
        {
            Id = 24124;
        }

        public override void Encode()
        {
            /*Writer.WriteHex("010001000000006eeb0fc2b9a5ffcc0b0000000fa90501010000000036cf844f1000009f9a0c9f9a0c010300000000");
            Writer.WriteScString("Mr Vitalik");
            Writer.WriteHex("a40180fcd91a80838129178c0117bf0300000006ffff0000000000");*/
            
        }
    }
}
