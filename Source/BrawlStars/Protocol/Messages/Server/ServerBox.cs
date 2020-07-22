using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;

namespace BrawlStars.Protocol.Messages.Server
{
    class ServerBox : PiranhaMessage
    {
        public ServerBox(Device device) : base(device)
        {
            Id = 24111;
        }

        private static int Gold { get; set; }
        private static int Gems { get; set; }
        public override void Encode()
        {
            int reward;
            Random rnd = new Random();
            Writer.WriteVInt(203);
            Writer.WriteVInt(0);
            Writer.WriteVInt(1);
            Writer.WriteVInt(Resources.Box);
            switch (Resources.Box)
            {
                case 10: //BrawlBox
                    Writer.WriteVInt(2);
                    Gold = rnd.Next(1, 1001);
                    Resources.Gold += Gold;
                    Writer.WriteVInt(Gold); //gold
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(7);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Gems = rnd.Next(1, 21);
                    Writer.WriteVInt(Gems); //gems
                    Writer.WriteVInt(1);
                    Writer.WriteVInt(0);
                    reward = rnd.Next(1,4);
                    switch (reward)
                    {
                        case 1:
                            Writer.WriteVInt(8); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            Resources.Gems += Gems;
                            break;
                        case 2:
                            Writer.WriteVInt(2); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            Resources.Tickets += Gems;
                            break;
                        case 3:
                            Writer.WriteVInt(3); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            break;
                    }

                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
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
                    break;
                case 11: //MegaBox
                    Writer.WriteVInt(2);
                    Gold = rnd.Next(1, 5001);
                    Resources.Gold += Gold;
                    Writer.WriteVInt(Gold); //gold
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(7);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Gems = rnd.Next(1, 101);
                    Writer.WriteVInt(Gems); //gems
                    Writer.WriteVInt(1);
                    Writer.WriteVInt(0);
                    reward = rnd.Next(1, 4);
                    switch (reward)
                    {
                        case 1:
                            Writer.WriteVInt(8); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            Resources.Gems += Gems;
                            break;
                        case 2:
                            Writer.WriteVInt(2); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            Resources.Tickets += Gems;
                            break;
                        case 3:
                            Writer.WriteVInt(3); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            break;
                    }
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
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
                    break;
                case 12: //BigBox
                    Writer.WriteVInt(2);
                    Gold = rnd.Next(1, 2501);
                    Resources.Gold += Gold;
                    Writer.WriteVInt(Gold); //gold
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(7);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Gems = rnd.Next(1, 51);
                    Writer.WriteVInt(Gems); //gems
                    Writer.WriteVInt(1);
                    Writer.WriteVInt(0);
                    reward = rnd.Next(1, 4);
                    switch (reward)
                    {
                        case 1:
                            Writer.WriteVInt(8); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            Resources.Gems += Gems;
                            break;
                        case 2:
                            Writer.WriteVInt(2); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            Resources.Tickets += Gems;
                            break;
                        case 3:
                            Writer.WriteVInt(3); //bonus reward type (gems = 8, token doubler = 2, tickets = 3)
                            break;
                    }
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
                    Writer.WriteVInt(0);
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
                    break;
            }

          /*Writer.WriteVInt(203);
            Writer.WriteVInt(0);
            Writer.WriteVInt(1);
            Writer.WriteVInt(Resources.Box);  //box ID (10 = mega box, 11 = brawl box, 12 = big box)
            Writer.WriteVInt(1);
            Writer.WriteVInt(1);
            Writer.WriteVInt(16);
            Writer.WriteVInt(7);
            Writer.WriteVInt(1);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteHex("0000000000ffff0000000000");*/
        }
    }
}
