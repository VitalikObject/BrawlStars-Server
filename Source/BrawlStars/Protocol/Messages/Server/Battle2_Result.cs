using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;

namespace BrawlStars.Protocol.Messages.Server
{
    class Battle2_Result : PiranhaMessage
    {
        public Battle2_Result(Device device) : base(device)
        {
            Id = 23456;
        }
        public int Rank { get; set; }
        public int Result { get; set; }
        public int Bot1Brawler { get; set; }
        public int Bot2Brawler { get; set; }
        public int Bot3Brawler { get; set; }
        public int Bot4Brawler { get; set; }
        public int Bot5Brawler { get; set; }
        public string Bot1Name { get; set; }
        public string Bot2Name { get; set; }
        public string Bot3Name { get; set; }
        public string Bot4Name { get; set; }
        public string Bot5Name { get; set; }

        public override async void Encode()
        {
            Writer.WriteVInt(1);
            Writer.WriteVInt(Result);
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
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(32);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(6);
            Writer.WriteVInt(1);
            Writer.WriteVInt(16);
            Writer.WriteVInt(Resources.Brawler);
            Writer.WriteVInt(29);
            Writer.WriteVInt(Resources.Skin);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(0);
            Writer.WriteVInt(10);
            Writer.WriteVInt(0);

            Writer.WriteScString(Resources.Name);

            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
            Writer.WriteVInt(0);
            Writer.WriteVInt(16);
            Writer.WriteVInt(Bot1Brawler);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(0);
            Writer.WriteVInt(10);
            Writer.WriteVInt(0);

            Writer.WriteScString(Bot1Name);

            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
            Writer.WriteVInt(0);
            Writer.WriteVInt(16);
            Writer.WriteVInt(Bot2Brawler);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(0);
            Writer.WriteVInt(10);
            Writer.WriteVInt(0);

            Writer.WriteScString(Bot2Name);

            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(Bot3Brawler);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(0);
            Writer.WriteVInt(10);
            Writer.WriteVInt(0);

            Writer.WriteScString(Bot3Name);

            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(Bot4Brawler);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(0);
            Writer.WriteVInt(10);
            Writer.WriteVInt(0);

            Writer.WriteScString(Bot4Name);

            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
            Writer.WriteVInt(2);
            Writer.WriteVInt(16);
            Writer.WriteVInt(Bot5Brawler);
            Writer.WriteVInt(0);
            Writer.WriteVInt(99999);
            Writer.WriteVInt(0);
            Writer.WriteVInt(10);
            Writer.WriteVInt(0);

            Writer.WriteScString(Bot5Name);

            Writer.WriteVInt(100);
            Writer.WriteVInt(28000000);
            Writer.WriteVInt(43000000);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(28);
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
