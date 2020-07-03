using BrawlStars.Logic;
using DotNetty.Buffers;

namespace BrawlStars.Protocol
{
    public class LogicCommand
    {
        public LogicCommand(Device device)
        {
            Device = device;
            Data = Unpooled.Buffer();
        }

        public LogicCommand(Device device, IByteBuffer buffer)
        {
            Device = device;
            Reader = buffer;
            Data = Unpooled.Buffer();
        }

        public IByteBuffer Data { get; set; }
        public Device Device { get; set; }

        public int Type { get; set; }
        public int Tick { get; set; }
        public IByteBuffer Reader { get; set; }

        public virtual void Decode()
        {
            Tick = Reader.ReadInt();
        }

        public virtual void Encode()
        {
        }

        public virtual void Process()
        {
        }

        public LogicCommand Handle()
        {
            Encode();
            return this;
        }
    }
}