using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using Colorful;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client
{
    class BattleEndMessage : PiranhaMessage
    {
        public BattleEndMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public int Rank { get; set; }
        private int Bot1 { get; set; }
        private int Bot2 { get; set; }
        private int Bot3 { get; set; }
        private int Bot4 { get; set; }
        private int Bot5 { get; set; }
        private string Bot1N { get; set; }
        private string Bot2N { get; set; }
        private string Bot3N { get; set; }
        private string Bot4N { get; set; }
        private string Bot5N { get; set; }
        private int GameType { get; set; }
        private int Team { get; set; }

        public override void Decode()
        {
            GameType = Reader.ReadVInt();
            Reader.ReadVInt();
            Rank = Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            Team = Reader.ReadVInt(); //red or blue
            Reader.ReadVInt();

            Reader.ReadScString(); //Your Name

            Reader.ReadVInt();
            Bot1 = Reader.ReadVInt(); //bot brawer
            Reader.ReadVInt();
            Reader.ReadVInt(); //red or blue
            Reader.ReadVInt();

            Bot1N = Reader.ReadScString();

            Reader.ReadVInt();
            Bot2 = Reader.ReadVInt(); //bot brawer
            Reader.ReadVInt();
            Reader.ReadVInt(); //red or blue
            Reader.ReadVInt();

            Bot2N = Reader.ReadScString();

            Reader.ReadVInt();
            Bot3 = Reader.ReadVInt(); //bot brawer
            Reader.ReadVInt();
            Reader.ReadVInt(); //red or blue
            Reader.ReadVInt();

            Bot3N = Reader.ReadScString();

            Reader.ReadVInt();
            Bot4 = Reader.ReadVInt(); //bot brawer
            Reader.ReadVInt();
            Reader.ReadVInt(); //red or blue
            Reader.ReadVInt();

            Bot4N = Reader.ReadScString();

            Reader.ReadVInt();
            Bot5 = Reader.ReadVInt(); //bot brawer
            Reader.ReadVInt();
            Reader.ReadVInt(); //red or blue
            Reader.ReadVInt();

            Bot5N = Reader.ReadScString();
        }
        public override async void Process()
        {
            if (Rank != 0)
            {
                await new Battle_Result(Device)
                {
                    Rank = Rank
                }.SendAsync();
            }
            else
            {
                if (Team == 0)
                {
                    await new Battle2_Result(Device)
                    {
                        Result = GameType,
                        Bot1Brawler = Bot1,
                        Bot2Brawler = Bot2,
                        Bot3Brawler = Bot3,
                        Bot4Brawler = Bot4,
                        Bot5Brawler = Bot5,
                        Bot1Name = Bot1N,
                        Bot2Name = Bot2N,
                        Bot3Name = Bot3N,
                        Bot4Name = Bot4N,
                        Bot5Name = Bot5N
                    }.SendAsync();
                }
                else
                {
                    await new Battle2_Result(Device)
                    {
                        Result = GameType,
                        Bot1Brawler = Bot4,
                        Bot2Brawler = Bot5,
                        Bot3Brawler = Bot3,
                        Bot4Brawler = Bot1,
                        Bot5Brawler = Bot2,
                        Bot1Name = Bot4N,
                        Bot2Name = Bot5N,
                        Bot3Name = Bot3N,
                        Bot4Name = Bot1N,
                        Bot5Name = Bot2N
                    }.SendAsync();
                }
            }
        }
    }
}
