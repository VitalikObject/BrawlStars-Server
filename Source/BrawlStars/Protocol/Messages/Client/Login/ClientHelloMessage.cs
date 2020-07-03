using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client.Login
{
    public class ClientHelloMessage : PiranhaMessage
    {
        public ClientHelloMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.Disconnected;
        }

        public int Protocol { get; set; }
        public int KeyVersion { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int Build { get; set; }
        public string FingerprintSha { get; set; }
        public int DeviceType { get; set; }
        public int AppStore { get; set; }

        public override void Decode()
        {
            Protocol = Reader.ReadInt();
            KeyVersion = Reader.ReadInt();
            MajorVersion = Reader.ReadInt();
            MinorVersion = Reader.ReadInt();
            Build = Reader.ReadInt();
            FingerprintSha = Reader.ReadScString();
            DeviceType = Reader.ReadInt();
            AppStore = Reader.ReadInt();
        }

        public override async void Process()
        {
            await new LoginFailedMessage(Device)
            {
                ErrorCode = 8
            }.SendAsync();
        }
    }
}