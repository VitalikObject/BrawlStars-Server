using BrawlStars.Logic;
using BrawlStars.Utilities.Netty;
using System;

namespace BrawlStars.Protocol.Messages.Server
{
    class ChatServerMessage : PiranhaMessage
    {
        public string Message { get; set; }
        public ChatServerMessage(Device device) : base(device)
        {
            Id = 24312;
        }
        Random rnd = new Random();
        public override async void Encode()
        {
            Writer.WriteVInt(2);
            Writer.WriteVInt(0);
            Writer.WriteVInt(Resources.MessageTick);
            Writer.WriteVInt(0);
            Writer.WriteVInt(1);
            Writer.WriteScString(Resources.Name);
            Writer.WriteVInt(2);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteScString(Message);
            Writer.WriteVInt(-1040385);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
            Writer.WriteVInt(0);
        }
    }
}
