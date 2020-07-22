using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
using System;

namespace BrawlStars.Protocol.Messages.Client
{
    class ChangeBrawlerInRoomMessage : PiranhaMessage
    {
        public ChangeBrawlerInRoomMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        private int BrawlerSkinId { get; set; }

        private int Unk { get; set; }

        public override void Decode()
        {
            Unk = Reader.ReadVInt();
            Reader.ReadVInt();
            BrawlerSkinId = Reader.ReadVInt();
        }
        public override async void Process()
        {
            if(Unk != 23)
            {
                Resources.Skin = BrawlerSkinId;
                switch (BrawlerSkinId)
                {
                    case 0:
                        Resources.Brawler = 0;
                        break;
                    case 29:
                        Resources.Brawler = 0;
                        break;
                    case 52:
                        Resources.Brawler = 0;
                        break;
                    case 122:
                        Resources.Brawler = 0;
                        break;
                    case 159:
                        Resources.Brawler = 0;
                        break;
                    case 14:
                        Resources.Brawler = 8;
                        break;
                    case 15:
                        Resources.Brawler = 8;
                        break;
                    case 60:
                        Resources.Brawler = 8;
                        break;
                    case 79:
                        Resources.Brawler = 8;
                        break;
                    case 148:
                        Resources.Brawler = 8;
                        break;
                    case 1:
                        Resources.Brawler = 1;
                        break;
                    case 2:
                        Resources.Brawler = 1;
                        break;
                    case 69:
                        Resources.Brawler = 1;
                        break;
                    case 103:
                        Resources.Brawler = 1;
                        break;
                    case 135:
                        Resources.Brawler = 1;
                        break;
                    case 3:
                        Resources.Brawler = 2;
                        break;
                    case 25:
                        Resources.Brawler = 2;
                        break;
                    case 64:
                        Resources.Brawler = 2;
                        break;
                    case 102:
                        Resources.Brawler = 2;
                        break;
                    case 178:
                        Resources.Brawler = 2;
                        break;
                    case 13:
                        Resources.Brawler = 7;
                        break;
                    case 44:
                        Resources.Brawler = 7;
                        break;
                    case 47:
                        Resources.Brawler = 7;
                        break;
                    case 123:
                        Resources.Brawler = 7;
                        break;
                    case 162:
                        Resources.Brawler = 7;
                        break;
                    case 174:
                        Resources.Brawler = 7;
                        break;
                    case 4:
                        Resources.Brawler = 3;
                        break;
                    case 5:
                        Resources.Brawler = 3;
                        break;
                    case 58:
                        Resources.Brawler = 3;
                        break;
                    case 72:
                        Resources.Brawler = 3;
                        break;
                    case 91:
                        Resources.Brawler = 3;
                        break;
                    case 6:
                        Resources.Brawler = 9;
                        break;
                    case 56:
                        Resources.Brawler = 9;
                        break;
                    case 57:
                        Resources.Brawler = 9;
                        break;
                    case 97:
                        Resources.Brawler = 9;
                        break;
                    case 160:
                        Resources.Brawler = 9;
                        break;
                    case 22:
                        Resources.Brawler = 14;
                        break;
                    case 94:
                        Resources.Brawler = 14;
                        break;
                    case 98:
                        Resources.Brawler = 14;
                        break;
                    case 99:
                        Resources.Brawler = 14;
                        break;
                    case 163:
                        Resources.Brawler = 14;
                        break;
                    case 86:
                        Resources.Brawler = 22;
                        break;
                    case 106:
                        Resources.Brawler = 27;
                        break;
                    case 109:
                        Resources.Brawler = 27;
                        break;
                    case 143:
                        Resources.Brawler = 27;
                        break;
                    case 119:
                        Resources.Brawler = 30;
                        break;
                    case 167:
                        Resources.Brawler = 30;
                        break;
                    case 7:
                        Resources.Brawler = 10;
                        break;
                    case 28:
                        Resources.Brawler = 10;
                        break;
                    case 30:
                        Resources.Brawler = 10;
                        break;
                    case 128:
                        Resources.Brawler = 10;
                        break;
                    case 12:
                        Resources.Brawler = 6;
                        break;
                    case 27:
                        Resources.Brawler = 6;
                        break;
                    case 59:
                        Resources.Brawler = 6;
                        break;
                    case 90:
                        Resources.Brawler = 6;
                        break;
                    case 92:
                        Resources.Brawler = 6;
                        break;
                    case 116:
                        Resources.Brawler = 6;
                        break;
                    case 21:
                        Resources.Brawler = 13;
                        break;
                    case 71:
                        Resources.Brawler = 13;
                        break;
                    case 140:
                        Resources.Brawler = 13;
                        break;
                    case 77:
                        Resources.Brawler = 24;
                        break;
                    case 9:
                        Resources.Brawler = 4;
                        break;
                    case 26:
                        Resources.Brawler = 4;
                        break;
                    case 68:
                        Resources.Brawler = 4;
                        break;
                    case 130:
                        Resources.Brawler = 4;
                        break;
                    case 171:
                        Resources.Brawler = 4;
                        break;
                    case 34:
                        Resources.Brawler = 18;
                        break;
                    case 70:
                        Resources.Brawler = 18;
                        break;
                    case 158:
                        Resources.Brawler = 18;
                        break;
                    case 41:
                        Resources.Brawler = 19;
                        break;
                    case 61:
                        Resources.Brawler = 19;
                        break;
                    case 88:
                        Resources.Brawler = 19;
                        break;
                    case 165:
                        Resources.Brawler = 19;
                        break;
                    case 73:
                        Resources.Brawler = 25;
                        break;
                    case 93:
                        Resources.Brawler = 25;
                        break;
                    case 104:
                        Resources.Brawler = 25;
                        break;
                    case 132:
                        Resources.Brawler = 25;
                        break;
                    case 134:
                        Resources.Brawler = 25;
                        break;
                    case 142:
                        Resources.Brawler = 34;
                        break;
                    case 176:
                        Resources.Brawler = 34;
                        break;
                    case 23:
                        Resources.Brawler = 15;
                        break;
                    case 108:
                        Resources.Brawler = 15;
                        break;
                    case 120:
                        Resources.Brawler = 15;
                        break;
                    case 147:
                        Resources.Brawler = 15;
                        break;
                    case 24:
                        Resources.Brawler = 16;
                        break;
                    case 179:
                        Resources.Brawler = 16;
                        break;
                    case 42:
                        Resources.Brawler = 20;
                        break;
                    case 45:
                        Resources.Brawler = 20;
                        break;
                    case 125:
                        Resources.Brawler = 20;
                        break;
                    case 81:
                        Resources.Brawler = 26;
                        break;
                    case 146:
                        Resources.Brawler = 26;
                        break;
                    case 114:
                        Resources.Brawler = 29;
                        break;
                    case 139:
                        Resources.Brawler = 29;
                        break;
                    case 156:
                        Resources.Brawler = 36;
                        break;
                    case 18:
                        Resources.Brawler = 11;
                        break;
                    case 50:
                        Resources.Brawler = 11;
                        break;
                    case 63:
                        Resources.Brawler = 11;
                        break;
                    case 75:
                        Resources.Brawler = 11;
                        break;
                    case 173:
                        Resources.Brawler = 11;
                        break;
                    case 32:
                        Resources.Brawler = 17;
                        break;
                    case 111:
                        Resources.Brawler = 17;
                        break;
                    case 145:
                        Resources.Brawler = 17;
                        break;
                    case 67:
                        Resources.Brawler = 21;
                        break;
                    case 117:
                        Resources.Brawler = 21;
                        break;
                    case 172:
                        Resources.Brawler = 21;
                        break;
                    case 127:
                        Resources.Brawler = 32;
                        break;
                    case 137:
                        Resources.Brawler = 32;
                        break;
                    case 121:
                        Resources.Brawler = 31;
                        break;
                    case 152:
                        Resources.Brawler = 31;
                        break;
                    case 157:
                        Resources.Brawler = 37;
                        break;
                    case 177:
                        Resources.Brawler = 37;
                        break;
                    case 10:
                        Resources.Brawler = 5;
                        break;
                    case 11:
                        Resources.Brawler = 5;
                        break;
                    case 96:
                        Resources.Brawler = 5;
                        break;
                    case 19:
                        Resources.Brawler = 12;
                        break;
                    case 20:
                        Resources.Brawler = 12;
                        break;
                    case 49:
                        Resources.Brawler = 12;
                        break;
                    case 95:
                        Resources.Brawler = 12;
                        break;
                    case 100:
                        Resources.Brawler = 12;
                        break;
                    case 101:
                        Resources.Brawler = 12;
                        break;
                    case 62:
                        Resources.Brawler = 23;
                        break;
                    case 110:
                        Resources.Brawler = 23;
                        break;
                    case 126:
                        Resources.Brawler = 23;
                        break;
                    case 131:
                        Resources.Brawler = 23;
                        break;
                    case 113:
                        Resources.Brawler = 28;
                        break;
                    case 118:
                        Resources.Brawler = 28;
                        break;
                    case 155:
                        Resources.Brawler = 35;
                        break;
                    case 180:
                        Resources.Brawler = 35;
                        break;
                }
                switch (Resources.Brawler)
                {
                    case 0: //Shelly
                        Resources.StarPower = 76;
                        Resources.Gadget = 255;
                        break;
                    case 1: //Colt
                        Resources.StarPower = 77;
                        Resources.Gadget = 273;
                        break;
                    case 2: //Bull
                        Resources.StarPower = 78;
                        Resources.Gadget = 272;
                        break;
                    case 3: //Brock
                        Resources.StarPower = 79;
                        Resources.Gadget = 245;
                        break;
                    case 4: //Rico
                        Resources.StarPower = 80;
                        Resources.Gadget = 246;
                        break;
                    case 5: //Spike
                        Resources.StarPower = 81;
                        Resources.Gadget = 247;
                        break;
                    case 6: //Barley
                        Resources.StarPower = 82;
                        Resources.Gadget = 273;
                        break;
                    case 7: //Jessie
                        Resources.StarPower = 83;
                        Resources.Gadget = 251;
                        break;
                    case 8: //Nita
                        Resources.StarPower = 84;
                        Resources.Gadget = 249;
                        break;
                    case 9: //Dynamike
                        Resources.StarPower = 85;
                        Resources.Gadget = 258;
                        break;
                    case 10: //El Primo
                        Resources.StarPower = 86;
                        Resources.Gadget = 264;
                        break;
                    case 11: //Mortis
                        Resources.StarPower = 87;
                        Resources.Gadget = 265;
                        break;
                    case 12: //Crow
                        Resources.StarPower = 88;
                        Resources.Gadget = 243;
                        break;
                    case 13: //Poco
                        Resources.StarPower = 89;
                        Resources.Gadget = 267;
                        break;
                    case 14: //Bo
                        Resources.StarPower = 90;
                        Resources.Gadget = 263;
                        break;
                    case 15: //Piper
                        Resources.StarPower = 91;
                        Resources.Gadget = 268;
                        break;
                    case 16: //PAM
                        Resources.StarPower = 92;
                        Resources.Gadget = 257;
                        break;
                    case 17: //Tara
                        Resources.StarPower = 93;
                        Resources.Gadget = 266;
                        break;
                    case 18: //Darryl
                        Resources.StarPower = 94;
                        Resources.Gadget = 260;
                        break;
                    case 19: //Penny
                        Resources.StarPower = 99;
                        Resources.Gadget = 248;
                        break;
                    case 20: //Frank
                        Resources.StarPower = 104;
                        Resources.Gadget = 261;
                        break;
                    case 21: //Gene
                        Resources.StarPower = 109;
                        Resources.Gadget = 252;
                        break;
                    case 22: //Tick
                        Resources.StarPower = 114;
                        Resources.Gadget = 253;
                        break;
                    case 23: //Leon
                        Resources.StarPower = 119;
                        Resources.Gadget = 276;
                        break;
                    case 24: //Rosa
                        Resources.StarPower = 124;
                        Resources.Gadget = 242;
                        break;
                    case 25: //Carl
                        Resources.StarPower = 129;
                        Resources.Gadget = 262;
                        break;
                    case 26: //Bibi
                        Resources.StarPower = 134;
                        Resources.Gadget = 275;
                        break;
                    case 27: //8-Bit
                        Resources.StarPower = 168;
                        Resources.Gadget = 259;
                        break;
                    case 28: //Sandy
                        Resources.StarPower = 186;
                        Resources.Gadget = 270;
                        break;
                    case 29: //Bea
                        Resources.StarPower = 192;
                        Resources.Gadget = 271;
                        break;
                    case 30: //EMZ
                        Resources.StarPower = 198;
                        Resources.Gadget = 274;
                        break;
                    case 31: //Mr. P
                        Resources.StarPower = 204;
                        Resources.Gadget = 269;
                        break;
                    case 32: //Max
                        Resources.StarPower = 210;
                        Resources.Gadget = 254;
                        break;
                    case 34: //Jacky
                        Resources.StarPower = 222;
                        Resources.Gadget = 256;
                        break;
                    case 37: //Sprout
                        Resources.StarPower = 240;
                        Resources.Gadget = 244;
                        break;
                }
                await new Gameroom_Data(Device).SendAsync();
            }
        }
    }
}
