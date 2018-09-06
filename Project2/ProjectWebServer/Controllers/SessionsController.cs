using ProjectWebServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectWebServer.Controllers
{
    public class SessionsController : ApiController
    {
        public List<Session> sessions = new List<Session>(
            new Session[]
            {
                new Session { SessionTitle = "Microsoft", SessionDescription = "Azure"},
                new Session { SessionTitle = "Google", SessionDescription = "Android"},
                new Session { SessionTitle = "Facebook", SessionDescription = "WhatsApp"},
                new Session { SessionTitle = "IBM", SessionDescription = "Watson"},
            });

        public List<Session> GetAll()
        {
            return sessions;
        }

        public Session GetSession(string id)
        {
            var session = sessions.FirstOrDefault(x => x.SessionTitle == id);
            return session;
        }
    }
}
