using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work
{
    public class MyHub : Hub
    {
        public void UpdateStatus(DateTime start, DateTime end)
        {
            Clients.All.UpdateStatus(start, end);
        }
    }
}