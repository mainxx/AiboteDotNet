using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.Session
{
    public sealed class SessionManager
    {
        internal static readonly ConcurrentDictionary<Guid, Session> sessionMap = new();
        public static int Count()
        {
            return sessionMap.Count;
        }

        public static List<Session> GetAllSession()
        {
            return sessionMap.Values.ToList();
        }

        public static void Remove(Guid id)
        {
            if (sessionMap.TryRemove(id, out var session))
            {
                session.Channel.Close();
            }
        }

        public static Task RemoveAll()
        {
            foreach (var session in sessionMap.Values)
            {
                session.Channel.Close();
            }
            sessionMap.Clear();
            return Task.CompletedTask;
        }

        public static Session Get(Guid id)
        {
            sessionMap.TryGetValue(id, out Session session);
            return session;
        }

        public static void Add(Session session)
        {
            if (sessionMap.TryGetValue(session.Id, out var oldSession) && oldSession.Channel != session.Channel)
            {
                // 新连接
                oldSession.Channel.Close();
            }
            sessionMap[session.Id] = session;
        }
    }
}
