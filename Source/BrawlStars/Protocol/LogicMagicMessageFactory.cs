using System;
using System.Collections.Generic;
using BrawlStars.Protocol.Messages.Client;
using BrawlStars.Protocol.Messages.Client.Alliance;
using BrawlStars.Protocol.Messages.Client.Home;
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
                {10212, typeof(SetNameMessage)},
                {10309, typeof(ClanInviteLinkMessage)},
                {14102, typeof(EndClientTurnMessage)},
                {14109, typeof(ExitMessage)},
                {14110, typeof(BattleEndMessage)},
                {14113, typeof(ProfileMessage)},
                {14302, typeof(OpenClubMessage)},
                {14315, typeof(ChatToClubMessage)},
                {14350, typeof(CreateGameroomMessage)},
                {14353, typeof(QuitRoomMessage)},
                {14354, typeof(ChangeBrawlerInRoomMessage)},
                {14363, typeof(ChangeMapMessage)},
                {14366, typeof(ClientActionMessage)},
                {14372, typeof(UseGadgetInRoomMessage)},
                {14600, typeof(ChangeNameMessage)},
                {14777, typeof(DoNotDistrubMessage)}
            };
        }
    }
}