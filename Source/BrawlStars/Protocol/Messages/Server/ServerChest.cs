using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;

namespace BrawlStars.Protocol.Messages.Server
{
    class ServerChest : PiranhaMessage
    {
        public ServerChest(Device device) : base(device)
        {

        }

        public override async void Encode()
        {
            /*await new LoginFailedMessage(Device)
            {
                Reason = $"Not implement yet"
            }.SendAsync();*/
        }
    }
}
