using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;

namespace BrawlStars.Protocol.Commands.Server
{
    public class LogicDiamondsAddedCommand : LogicCommand
    {
        public LogicDiamondsAddedCommand(Device device) : base(device)
        {
            Type = 7;
        }

        public int Diamonds { get; set; }

        public override void Encode()
        {
            Data.WriteBoolean(false); // AllianceGift

            Data.WriteInt(Diamonds);

            Data.WriteInt(0);
            Data.WriteInt(0);
            Data.WriteInt(0);

            Data.WriteScString("GPA.0000-0000-0000-00000"); // Transaction Id
        }
    }
}