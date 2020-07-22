using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;
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
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Random rnd = new Random();
            if (Resources.RoomID == 0)
            {
                int i = rnd.Next(0, 2147483647);
                Resources.RoomID = i;
                Writer.WriteInt(i);
            }
            else 
            {
                Writer.WriteInt(Resources.RoomID);
            }
            Writer.WriteVInt(1557129593);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(15);
            Writer.WriteVInt(Resources.Map);
            Writer.WriteVInt(1);
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0); //High id
            Writer.WriteInt(1); //Low Id
            Writer.WriteVInt(16);
            Writer.WriteVInt(Resources.Brawler);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(1);
            Writer.WriteVInt(3);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteScString(Resources.Name);
            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
            Writer.WriteVInt(23);
            Writer.WriteVInt(Resources.StarPower); //star power
            if (Resources.UseGadget == true)
            {
                Writer.WriteVInt(23);
                Writer.WriteVInt(Resources.Gadget); //gadget
            }
            else 
            {
                Writer.WriteVInt(0);
                Writer.WriteVInt(0);
            }
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(6);
            Writer.WriteVInt(-1040385);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
        }
    }
}
