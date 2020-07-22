using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
using System;
using System.Linq;
using BrawlStars.Utilities;
using System.Runtime.InteropServices;
using Google.Protobuf.WellKnownTypes;

namespace BrawlStars.Protocol.Messages.Client.Alliance
{
    class ChatToClubMessage : PiranhaMessage
    {
        public ChatToClubMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public string Messages { get; set; }
        private ChatServerMessage Chat { get; set; }

        public override void Decode()
        {
            Messages = Reader.ReadScString();
        }

        public override async void Process()
        {
            string Botmsg = string.Empty;
            if (Messages.StartsWith("/"))
            {
                var cmd = Messages.Split(' ');
                var cmdType = cmd[0];
                var cmdValue = 0;

                if (cmd.Length > 1)
                    if (Messages.Split(' ')[1].Any(char.IsDigit))
                        int.TryParse(Messages.Split(' ')[1], out cmdValue);
                switch (cmdType)
                {
                    case "/status":
                        Resources.MessageTick++;
                        Botmsg = $"Server status:\nBuild version: 1.2(for 26.165)\nFingerprint SHA:\n{ Resources.Fingerprint.Sha}\nUsed Ram: " +
$"{System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024) + " MB"}";
                        Resources.ChatMessage = Messages;
                        await new ChatServerMessage(Device)
                        {
                            Message = Resources.ChatMessage
                        }.SendAsync();
                        Resources.MessageTick++;
                        await new ChatBotServerMessage(Device)
                        {
                            Message =
                            Botmsg
                        }.SendAsync();
                        break;
                    case "/about":
                        Resources.MessageTick++;
                        Botmsg = "By VitalikObject and PhoenixFire";
                        Resources.ChatMessage = Messages;
                        await new ChatServerMessage(Device)
                        {
                            Message = Resources.ChatMessage
                        }.SendAsync();
                        Resources.MessageTick++;
                        await new ChatBotServerMessage(Device)
                        {
                            Message =
                            Botmsg
                        }.SendAsync();
                        break;
                    case "/reset":
                        Resources.Gems = 99999;
                        Resources.Gold = 99999;
                        Resources.Tickets = 99999;
                        await new LoginFailedMessage(Device)
                        {
                            Reason =
                            "You should re-enter the game to apply changes"
                        }.SendAsync();
                        break;
                    case "/help":
                        Resources.MessageTick++;
                        Resources.ChatMessage = Messages;
                        await new ChatServerMessage(Device)
                        {
                            Message = Resources.ChatMessage
                        }.SendAsync();
                        Resources.MessageTick++;
                        Botmsg = "/status - shows server status\n/about - authors\n/reset - set resources by default";
                        await new ChatBotServerMessage(Device)
                        {
                            Message =
                            Botmsg
                        }.SendAsync();
                        break;
                }
            }
            else 
            {
                Resources.ChatMessage = Messages;
                Resources.MessageTick++;
                await new ChatServerMessage(Device)
                {
                    Message = Resources.ChatMessage
                }.SendAsync();
            }
        }
    }
}
