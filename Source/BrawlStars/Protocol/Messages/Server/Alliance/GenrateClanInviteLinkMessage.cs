using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;

namespace BrawlStars.Protocol.Messages.Server.Alliance
{
    class GenrateClanInviteLinkMessage : PiranhaMessage
    {
        public GenrateClanInviteLinkMessage(Device device) : base(device)
        {
            Id = 23302;
        }
        public override async void Encode()
        {
            Random rnd = new Random();
            int itoken = rnd.Next(1, 2147483647);
            string token = itoken.ToString();
            Writer.WriteVInt(1);
            Writer.WriteScString(token);
            Writer.WriteVInt(-1040385);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
        }
    }
}
