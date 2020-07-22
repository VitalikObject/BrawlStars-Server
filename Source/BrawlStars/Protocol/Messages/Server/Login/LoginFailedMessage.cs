using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;

namespace BrawlStars.Protocol.Messages.Server
{
    public class LoginFailedMessage : PiranhaMessage
    {
        public LoginFailedMessage(Device device) : base(device)
        {
            Id = 20103;
            Version = 4;
        }

        public byte ErrorCode { get; set; }
        public int SecondsUntilMaintenanceEnds { get; set; }
        public string Reason { get; set; }
        public string ResourceFingerprintData { get; set; }
        public string ContentUrl { get; set; }
        public string UpdateUrl { get; set; }

        // 1  = Custom Message
        // 7  = Patch
        // 8  = Update Available
        // 9  = Failed to Connect
        // 10 = Maintenance
        // 11 = Banned
        // 13 = Acc Locked PopUp
        // 16 = Updating Cr/Maintenance
        // 18 = Chinese Text?

        public override void Encode()
        {
            Writer.WriteInt(ErrorCode); // ErrorCode
            Writer.WriteScString(ResourceFingerprintData);
            Writer.WriteScString(null);
            Writer.WriteScString(ContentUrl);
            Writer.WriteScString(UpdateUrl); // Update URL
            Writer.WriteScString(Reason);
            Writer.WriteHex("2E0000012C000000000000000000");
            Writer.WriteScString(null);
            Writer.WriteScString(null);
            Writer.WriteScString(null);
            Writer.WriteScString(null);
            Writer.WriteHex("00FFFF0000000000");
        }
    }
}