using System.Threading.Tasks;
using BrawlStars.Protocol;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace BrawlStars.Core.Network.Handlers
{
    public class PacketEncoder : ChannelHandlerAdapter
    {
        public override Task WriteAsync(IChannelHandlerContext context, object msg)
        {
            var message = (PiranhaMessage) msg;

            message.Encode();

            var header = PooledByteBufferAllocator.Default.Buffer(7);
            header.WriteUnsignedShort(message.Id);
            header.WriteMedium(message.Writer.ReadableBytes);
            header.WriteUnsignedShort(message.Version);

            message.EncodeCryptoBytes();

            base.WriteAsync(context, header);
            return base.WriteAsync(context, message.Writer);
        }
    }
}