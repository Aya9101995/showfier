using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MWCore.HttpHandlers
{
    /// <summary>
    /// Summary description for MainHandler
    /// </summary>
    public class MainHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Session["HeartBeat"] = DateTime.Now;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}