using System;
using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;

namespace BrawlStars.Protocol.Messages.Server
{
    public class ProfileServerMessage : PiranhaMessage
    {
        public ProfileServerMessage(Device device) : base(device)
        {
            Id = 24113;
        }

        public override void Encode()
        {
            Writer.WriteVInt(0); //High Id
            Writer.WriteVInt(1); //Low Id
            Writer.WriteVInt(0);
            Writer.WriteVInt(7);
            Writer.WriteVInt(16);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(9);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(22);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(14);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(7);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(8);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(2);
            Writer.WriteVInt(14);
            Writer.WriteVInt(1);
            Writer.WriteVInt(99999); //3v3 victories
            Writer.WriteVInt(2);
            Writer.WriteVInt(1262469); //exp
            Writer.WriteVInt(3);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(4);
            Writer.WriteVInt(Resources.Trophies); //highest trophies
            Writer.WriteVInt(5);
            Writer.WriteVInt(7);
            Writer.WriteVInt(7);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(8);
            Writer.WriteVInt(99999); //solo victories
            Writer.WriteVInt(9);
            Writer.WriteVInt(21);
            Writer.WriteVInt(10);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(11);
            Writer.WriteVInt(99999); //duo victories
            Writer.WriteVInt(12);
            Writer.WriteVInt(21);
            Writer.WriteVInt(13);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(14);
            Writer.WriteVInt(1);
            Writer.WriteVInt(15);
            Writer.WriteVInt(99999); //most challenge wins
            Writer.WriteScString(Resources.Name);
            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
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