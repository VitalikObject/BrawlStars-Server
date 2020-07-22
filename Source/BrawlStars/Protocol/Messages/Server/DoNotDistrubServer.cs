using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;
using System.Text;

namespace BrawlStars.Protocol.Messages.Server
{
    class DoNotDistrubServer : PiranhaMessage
    {
        public DoNotDistrubServer(Device device) : base(device)
        {
            Id = 24111;
        }
        public bool Distrub { get; set; }
        public override async void Encode()
        {
            Writer.WriteVInt(213);
            Writer.WriteBoolean(Distrub);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(-1040385);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
        }
    }
}
