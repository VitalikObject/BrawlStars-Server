using System;
using System.Globalization;
using BrawlStars.Logic;
using BrawlStars.Logic.Sessions;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
using BrawlStars;

namespace BrawlStars.Protocol.Messages.Client.Login
{
    class ExitMessage : PiranhaMessage
    {
        public ExitMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public override async void Process()
        {
            await new OwnHomeDataMessage(Device).SendAsync();
        }
    }
}
