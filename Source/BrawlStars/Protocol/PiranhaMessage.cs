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
        public bool IsServerToClientMessage => Id - 0x4E20 > 0x00;

        public bool IsClientToServerMessage => Id - 0x2710 < 0x2710;

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
                Logger.Log($"Failed to send {Id}.", GetType(), Logger.ErrorLevel.Debug);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"PACKET ID: {Id}, ");
            builder.Append($"PACKET LENGTH: {Length}, ");
            builder.Append($"PACKET VERSION: {Version}, ");
            builder.Append($"STC: {IsServerToClientMessage}, ");
            builder.Append($"CTS: {IsClientToServerMessage}, ");
            Reader.SetReaderIndex(7);
            builder.Append($"Content: {ByteBufferUtil.HexDump(Reader.ReadBytes(Length))}");
            Reader.SetReaderIndex(7);
            return builder.ToString();
        }
    }
}