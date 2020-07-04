using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;

namespace BrawlStars.Protocol.Commands.Server
{
    public class LogicChangeAvatarName : LogicCommand
    {
        public LogicChangeAvatarName(Device device) : base(device)
        {
            Type = 3;
        }

        public string Name { get; set; }

        public override void Encode()
        {
            Data.WriteScString(Name);
        }
    }
}