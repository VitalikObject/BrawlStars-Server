using System;
using System.Diagnostics;
using System.Net;
using BrawlStars.Core.Network.Handlers;
using BrawlStars.Logic.Sessions;
using BrawlStars.Protocol;
using BrawlStars.Protocol.Messages.Server;
using DotNetty.Buffers;

namespace BrawlStars.Logic
{
    public class Device
    {
        public Device(PacketHandler handler)
        {
            Handler = handler;
            CurrentState = State.Disconnected;
        }

        public bool IsConnected => Handler.Channel.Registered;

        /// <summary>
        ///     Process a message
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void Process(IByteBuffer buffer)
        {
            var id = buffer.ReadUnsignedShort();
            var length = buffer.ReadMedium();
            var version = buffer.ReadUnsignedShort();

            if (id < 10000 || id >= 20000) return;

            if (!LogicMagicMessageFactory.Messages.ContainsKey(id))
            {
                Logger.Log($"Message ID: {id}, V: {version}, L: {length} is not known.", GetType(),
                    Logger.ErrorLevel.Warning);

                //Disconnect($"Message ID: {id}, V: {version}, L: {length} is not known.");
                return;
            }

            if (!(Activator.CreateInstance(LogicMagicMessageFactory.Messages[id], this, buffer) is PiranhaMessage
                message)) return;

            try
            {
                if (message.RequiredState != CurrentState && message.RequiredState != State.NotDefinied)
                {
                    Logger.Log($"Message {id} is not allowed in state {CurrentState.ToString()}!", GetType(),
                        Logger.ErrorLevel.Warning);
                    Disconnect("Not allowed.");
                    return;
                }

                message.Id = id;
                message.Length = length;
                message.Version = version;

#if DEBUG
                var st = new Stopwatch();
                st.Start();
#endif

                message.Decode();
                message.Process();

#if DEBUG
                st.Stop();
                Logger.Log($"Message {id}:{length} ({message.GetType().Name}) - ({st.ElapsedMilliseconds}ms)",
                    GetType(),
                    Logger.ErrorLevel.Debug);
#endif

                if (message.Save && CurrentState == State.Home) Player.Save();
            }
            catch (Exception exception)
            {
                Logger.Log($"Failed to process {id}, L: {length}: " + exception, GetType(), Logger.ErrorLevel.Error);
            }
        }

        /// <summary>
        ///     Returns the Ipv4 Address of the client
        /// </summary>
        /// <returns></returns>
        public string GetIp()
        {
            return ((IPEndPoint) Handler.Channel.RemoteAddress).Address.MapToIPv4().ToString();
        }

        /// <summary>
        ///     Disconnect a client by sending OutOfSyncMessage
        /// </summary>
        /// <returns></returns>
        public async void Disconnect(string reason = null)
        {
            if (reason != null)
            {
                await new LoginFailedMessage(this)
                {
                    Reason = reason
                }.SendAsync();
            }
            else
            {
                //await new OutOfSyncMessage(this).SendAsync();

                try
                {
                    await Handler.Channel.CloseAsync();
                }
                catch (Exception)
                {
                    Logger.Log("Failed to close channel", GetType(), Logger.ErrorLevel.Error);
                }
            }
        }

        #region Objects

        public Session Session = new Session();
        public PacketHandler Handler { get; set; }

        public Player Player { get; set; }

        public DateTime LastVisitHome { get; set; }
        public DateTime LastSectorCommand { get; set; }

        public State CurrentState { get; set; }

        public enum State
        {
            Disconnected = 0,
            Login = 1,
            Battle = 2,
            Home = 3,
            Visit = 4,
            NotDefinied = 5
        }

        #endregion Objects
    }
}