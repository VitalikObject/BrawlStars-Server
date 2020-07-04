using System;
using System.Net;
using BrawlStars.Logic;
using DotNetty.Buffers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;

namespace BrawlStars.Core.Network.Handlers
{
    public class PacketHandler : ChannelHandlerAdapter
    {
        public PacketHandler()
        {
            Throttler = new Throttler(10, 500);
            Device = new Device(this);
        }

        public Device Device { get; set; }
        public IChannel Channel { get; set; }
        public Throttler Throttler { get; set; }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = (IByteBuffer) message;
            if (buffer == null) return;

            if (Throttler.CanProcess())
            {
                Device.Process(buffer);
            }
            else
            {
                Logger.Log("Client reached ratelimit. Disconnecting...", GetType(), Logger.ErrorLevel.Warning);
                Device.Disconnect();
            }
        }

        public override void ChannelRegistered(IChannelHandlerContext context)
        {
            Channel = context.Channel;

            var remoteAddress = (IPEndPoint) Channel.RemoteAddress;

            Logger.Log($"Client {remoteAddress.Address.MapToIPv4()}:{remoteAddress.Port} connected.", GetType(),
                Logger.ErrorLevel.Debug);

            base.ChannelRegistered(context);
        }

        public override async void ChannelUnregistered(IChannelHandlerContext context)
        {
            if (Device?.Player?.Home != null)
            {
                var player = await Resources.Players.GetPlayerAsync(Device.Player.Home.Id, true);
                if (player != null)
                    if (player.Device.Session.SessionId == Device.Session.SessionId)
                        Resources.Players.LogoutById(player.Home.Id);
            }

            var remoteAddress = (IPEndPoint) Channel.RemoteAddress;

            Logger.Log($"Client {remoteAddress.Address.MapToIPv4()}:{remoteAddress.Port} disconnected.", GetType(),
                Logger.ErrorLevel.Debug);

            base.ChannelUnregistered(context);
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            if (exception.GetType() != typeof(ReadTimeoutException) &&
                exception.GetType() != typeof(WriteTimeoutException))
                Logger.Log(exception, GetType(), Logger.ErrorLevel.Error);

            context.CloseAsync();
        }
    }
}