using System;
using System.Collections.Generic;
using BrawlStars.Protocol.Messages.Client;
using BrawlStars.Protocol.Messages.Client.Login;
using BrawlStars.Protocol.Messages.Server;

namespace BrawlStars.Protocol
{
    public class LogicMagicMessageFactory
    {
        public static Dictionary<int, Type> Messages;

        static LogicMagicMessageFactory()
        {
            Messages = new Dictionary<int, Type>
            {
                {10100, typeof(ClientHelloMessage)},
                {10101, typeof(LoginMessage)},
                {10108, typeof(KeepAliveMessage)},
                {10110, typeof(AnalyticsEventMessage)},
                {14109, typeof(ExitMessage)}
            };
        }
    }
}