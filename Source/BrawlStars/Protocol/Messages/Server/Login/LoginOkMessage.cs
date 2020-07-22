using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;

namespace BrawlStars.Protocol.Messages.Server
{
    public class LoginOkMessage : PiranhaMessage
    {
        public LoginOkMessage(Device device) : base(device)
        {
            Id = 20104;
            Version = 1;
        }

        public override void Encode()
        {


            Writer.WriteLong(1);
            Writer.WriteLong(1);

            Writer.WriteScString("jcdyo6zcyjuo1dch9jkpc14meft4siwmfq7iktss");

            Writer.WriteVInt(1);
            Writer.WriteVInt(-8165);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(1);
            Writer.WriteScString("prod");
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(2);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(44);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteScString("1589977040459");
            Writer.WriteScString("1578395063000");
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteHex("ffffffff");
            Writer.WriteScString("EN");
            Writer.WriteHex("ffffffff");
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(1);
            Writer.WriteHex("ffffffff");
            Writer.WriteScString("https://game-assets.brawlstarsgame.com");
            Writer.WriteScString("http://a678dbc1c015a893c9fd-4e8cc3b1ad3a3c940c504815caefa967.r87.cf2.rackcdn.com");
            Writer.WriteScString("https://event-assets.brawlstars.com");
            Writer.WriteScString("https://24b999e6da07674e22b0-8209975788a0f2469e68e84405ae4fcf.ssl.cf2.rackcdn.com/event-assets");        }
    }
}