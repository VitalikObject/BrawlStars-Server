using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System.Text;

namespace BrawlStars.Protocol.Messages.Server.Login
{
    class Copyright : PiranhaMessage
    {
        public Copyright(Device device) : base(device)
        {
            Id = 9999;
        }

        public override void Encode()
        {
            Writer.WriteScString("Do not go there! It's dangerous there! Go away!\n");
            Writer.WriteScString("(c) Mr Vitalik & PhoenixFire\n");
            Writer.WriteScString("2020");
        }
    }
}
