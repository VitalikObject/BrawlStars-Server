using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
using Renci.SshNet;
using System;
using System.Reflection;

namespace BrawlStars.Protocol.Messages.Client
{
    public class EndClientTurnMessage : PiranhaMessage
    {
        public EndClientTurnMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        private int CommandId { get; set; }
        private int BoxId { get; set; }
        private int BoxType { get; set; }
        private int Command { get; set; }
        public override void Decode()
        {
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Command = Reader.ReadVInt();
            if (Command != 0)
            {
                CommandId = Reader.ReadVInt();
            }
            else
            {
                CommandId = 0;
            }
        }

        public override async void Process()
        {
            switch (CommandId)
            {
                case 0:
                    break;
                case 203:

                    break;
                case 500:
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //-1
                    BoxId = Reader.ReadVInt();
                    switch (BoxId)
                    {
                        case 1:
                            Resources.Box = 12;
                            break;
                        case 3:
                            Resources.Box = 11;
                            break;
                        case 4:
                            Resources.Box = 12;
                            break;
                        case 5:
                            Resources.Box = 10;
                            break;
                    }
                    await new ServerBox(Device).SendAsync();
                    break;
                case 505:
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //28
                    Resources.ProfileIcon = Reader.ReadVInt();
                    break;
                case 506:
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //29
                    Resources.Skin = Reader.ReadVInt(); //SkinId
                    Reader.ReadVInt(); //525
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //16
                    Resources.Brawler = Reader.ReadVInt();
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
                    break;
                case 515:
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //-1
                    BoxType = Reader.ReadVInt();
                    break;
                case 527:
                    Reader.ReadVInt();
                    Reader.ReadVInt();
                    Reader.ReadVInt();
                    Reader.ReadVInt();
                    Reader.ReadVInt();
                    Resources.NameColor = Reader.ReadVInt();
                    break;
                case 529:
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //Unk
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //-1
                    Reader.ReadVInt(); //23
                    Resources.StarPower = Reader.ReadVInt();
                    if (Resources.Room == 1)
                        await new Gameroom_Data(Device).SendAsync();
                    break;
                case 535:
                    Resources.Box = 12;
                    await new ServerBox(Device).SendAsync();
                    break;
                default:
                    Logger.Log(
    $"Command {CommandId} is unhandled. Content: {ToString()}",
    GetType(), Logger.ErrorLevel.Warning);
                    break;
            }
        }
    }
}