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
            var home = Device.Player.Home;

            Writer.WriteLong(home.Id);
            Writer.WriteLong(home.Id);

            Writer.WriteScString(Device.Player.Home.UserToken);

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
            Writer.WriteScString("https://24b999e6da07674e22b0-8209975788a0f2469e68e84405ae4fcf.ssl.cf2.rackcdn.com/event-assets");
            Writer.WriteHex("000000011046010000789c254e4b728230003d519d20a0e3523eb189044c01816c3a8a202101ad5563387dcd74f9feafd1f87628284f381e484f5c964999a440c519eca28c6a16d4f724c082f9c0653d75aac91b485139ac0879e463d0946b93ddee2d6a7077dcd406c37c4256ccf16ad668acfe07d0146567379e288883dc98d5c9470bc489ce73a2537151440ac38f556149d45ff87103275622c3c9e3589962550f2b81b8e295ed01d45f413deee55b9faab9142c458bd327b658aa382b3bf5ee78c5995024a36e1250d5d299f8f19ff7eb7684317990f7dfa901fbc3b229bdeeec34ed8580b9a75fb17a0eb04fc3df3371a1b34b486d6f74648fa70ffbd97e2febf6f6b53e7821097625848fbe557fc6776f0d03ffffffff0000001841414142636a49455141367348527a4f4141487047673d3dffffffffffff0000000000");
        }
    }
}