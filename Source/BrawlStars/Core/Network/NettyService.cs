using System.Net;
using System.Threading.Tasks;
using BrawlStars.Core.Network.Handlers;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace BrawlStars.Core.Network
{
    public class NettyService
    {
        public MultithreadEventLoopGroup BossGroup { get; set; }
        public MultithreadEventLoopGroup WorkerGroup { get; set; }

        public ServerBootstrap ServerBootstrap { get; set; }
        public IChannel ServerChannel { get; set; }

        /// <summary>
        ///     Run the server
        /// </summary>
        /// <returns></returns>
        public async Task RunServerAsync()
        {
            BossGroup = new MultithreadEventLoopGroup();
            WorkerGroup = new MultithreadEventLoopGroup();

            ServerBootstrap = new ServerBootstrap();
            ServerBootstrap.Group(BossGroup, WorkerGroup);
            ServerBootstrap.Channel<TcpServerSocketChannel>();

            ServerBootstrap
                .Option(ChannelOption.SoBacklog, 100)
                .Option(ChannelOption.TcpNodelay, true)
                .Option(ChannelOption.SoKeepalive, true)
                .Handler(new LoggingHandler("SRV-ICR"))
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    var pipeline = channel.Pipeline;
                    pipeline.AddFirst("FrameDecoder", new LengthFieldBasedFrameDecoder(4096, 2, 3, 2, 0));
                    pipeline.AddFirst("ReadTimeoutHandler", new ReadTimeoutHandler(30));
                    pipeline.AddLast("PacketHandler", new PacketHandler());
                    pipeline.AddLast("WriteTimeoutHandler", new WriteTimeoutHandler(30));
                    pipeline.AddLast("PacketEncoder", new PacketEncoder());
                }));

            ServerChannel = await ServerBootstrap.BindAsync(Resources.Configuration.ServerPort);
            var endpoint = (IPEndPoint) ServerChannel.LocalAddress;

            Logger.Log(
                $"Listening on {endpoint.Address.MapToIPv4()}:{endpoint.Port}. Let's play Brawl Stars!",
                GetType());
        }

        /// <summary>
        ///     Close all channels and disconnects clients
        /// </summary>
        /// <returns></returns>
        public async Task Shutdown()
        {
            await ServerChannel.CloseAsync();
        }

        /// <summary>
        ///     Shutdown all workers of netty
        /// </summary>
        /// <returns></returns>
        public async Task ShutdownWorkers()
        {
            await WorkerGroup.ShutdownGracefullyAsync();
            await BossGroup.ShutdownGracefullyAsync();
        }
    }
}