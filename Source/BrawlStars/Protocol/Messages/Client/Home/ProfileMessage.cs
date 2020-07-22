using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using Colorful;
using DotNetty.Buffers;
using System.Net.Http.Headers;

namespace BrawlStars.Protocol.Messages.Client.Home
{
    class ProfileMessage : PiranhaMessage
    {
        public ProfileMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public int HighId { get; set; }

        public override void Decode()
        {
            Reader.ReadVInt();
            Reader.ReadVInt();
            Reader.ReadVInt();
            HighId = Reader.ReadVInt();
        }

        public override async void Process()
        {
            if (HighId == 0)
            {
                await new ProfileServerMessage(Device).SendAsync();
            }
            else 
            {
                await new BotProfileMessage(Device).SendAsync();
            }
        }
    }
}
