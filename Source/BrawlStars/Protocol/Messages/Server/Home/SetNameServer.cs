using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;

namespace BrawlStars.Protocol.Messages.Server.Home
{
    class SetNameServer : PiranhaMessage
    {
        public SetNameServer(Device device) : base(device)
        {
            Id = 24111;
        }

        public override async void Encode()
        {
            Writer.WriteVInt(201);
            Writer.WriteScString(Resources.Name);
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
        }
    }
}
