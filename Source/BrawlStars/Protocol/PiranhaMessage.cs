using System;
using System.Text;
using System.Threading.Tasks;
using BrawlStars.Logic;
using DotNetty.Buffers;

namespace BrawlStars.Protocol
{
    public class PiranhaMessage
    {
        public Device.State RequiredState = Device.State.Home;

        public PiranhaMessage(Device device)
        {
            Device = device;
            Writer = Unpooled.Buffer();
        }

        public PiranhaMessage(Device device, IByteBuffer buffer)
        {
            Device = device;
            Reader = buffer;
        }

        public IByteBuffer Writer { get; set; }
        public IByteBuffer Reader { get; set; }
        public Device Device { get; set; }
        public ushort Id { get; set; }
        public int Length { get; set; }
        public ushort Version { get; set; }
        public bool Save { get; set; }

        public virtual void Decode()
        {
        }

        public virtual void Encode()
        {
        }

        public virtual void Process()
        {
        }

        public void EncodeCryptoBytes()
        {
            Writer.WriteShort(-1);
            Writer.WriteByte(0);
            Writer.WriteInt(0);
        }

        /// <summary>
        ///     Writes this message to the clients channel
        /// </summary>
        /// <returns></returns>
        public async Task SendAsync()
        {
            try
            {
                await Device.Handler.Channel.WriteAndFlushAsync(this);

                Logger.Log($"[S] Message {Id} ({GetType().Name}) sent.", GetType(), Logger.ErrorLevel.Debug);
            }
            catch (Exception)
            {
                //Logger.Log($"Failed to send {Id}.", GetType(), Logger.ErrorLevel.Debug);
            }
        }

        public override string ToString()
        {
            Reader.SetReaderIndex(7);
            return ByteBufferUtil.HexDump(Reader.ReadBytes(Length));
        }
    }
}
