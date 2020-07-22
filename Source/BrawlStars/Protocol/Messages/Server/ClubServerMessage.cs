using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;

namespace BrawlStars.Protocol.Messages.Server
{
    class ClubServerMessage : PiranhaMessage
    {
        public ClubServerMessage(Device device) : base(device)
        {
            Id = 24301;
        }
        public override void Encode()
        {
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteInt(1);
            Writer.WriteScString("Brawl Private Server");
            Writer.WriteVInt(8);
            Writer.WriteVInt(5);
            Writer.WriteVInt(3);
            Writer.WriteVInt(1);
            Writer.WriteVInt(Resources.Trophies);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteScString(Resources.Region);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteScString("Server created by PhoenixFire and VitalikObject");
            Writer.WriteVInt(1);
            Writer.WriteInt(0);
            Writer.WriteInt(1); //Low Id
            Writer.WriteVInt(2);
            Writer.WriteVInt(Resources.Trophies);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteScString(Resources.Name);
            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000 + Resources.ProfileIcon);
            Writer.WriteVInt(43000000 + Resources.NameColor);
            Writer.WriteVInt(-1);
            Writer.WriteVInt(-1040385);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
        }
    }
}
