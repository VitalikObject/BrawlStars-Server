using BrawlStars.Core;
using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
using System;
using System.Threading.Tasks;

namespace BrawlStars.Protocol.Messages.Client
{
    class ChangeNameMessage : PiranhaMessage
    {
        public ChangeNameMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }
        public static string Name { get; set; }
        public override void Decode()
        {
            Name = Reader.ReadScString();
        }
        public override async void Process()
        {
            await new LoginFailedMessage(Device)
            {
                Reason =
                        "Not implemented yet"
            }.SendAsync();
        }
    }
}
