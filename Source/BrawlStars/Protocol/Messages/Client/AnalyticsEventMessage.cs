using BrawlStars.Logic;
using BrawlStars.Protocol.Messages.Server;
using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;

namespace BrawlStars.Protocol.Messages.Client
{
    class AnalyticsEventMessage : PiranhaMessage
    {
        public AnalyticsEventMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            RequiredState = Device.State.NotDefinied;
        }

        public string EventName { get; set; }
        public string Event { get; set; }

        public override void Decode()
        {
            EventName = Reader.ReadScString();
            Event = Reader.ReadScString();
        }

        public override void Process()
        {
            Logger.Log($"Name: {EventName}, Event: {Event}", GetType(), Logger.ErrorLevel.Debug);
        }
    
    }
}
