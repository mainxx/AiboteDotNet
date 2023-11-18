
using AiboteDotNet.Core.Session;
using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AiboteDotNet.Core.Tcp
{
    public class TcpConnectionHandler : ConnectionHandler
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        public TcpConnectionHandler() { }

        public virtual BotOptions CurBotOptions { get; set; } = BotOptions.None;

        public override async Task OnConnectedAsync(ConnectionContext connection)
        {
            LOGGER.Debug($"{connection.RemoteEndPoint?.ToString()} 链接成功");
            TcpChannel channel = null;
            channel = new TcpChannel(connection, CurBotOptions, async (session) => await OnRun(channel, session));
            await channel.StartAsync();
            LOGGER.Debug($"{channel.RemoteAddress} 断开链接");
            OnDisconnection(channel);
        }

        protected virtual void OnDisconnection(TcpChannel channel)
        {
            SessionManager.Remove(channel.SessionId);
        }
        protected virtual Task OnRun(TcpChannel channel, Session.Session session)
        {
            LOGGER.Debug($"执行{CurBotOptions} OnRun()");
            return Task.CompletedTask;
        }


    }
}
