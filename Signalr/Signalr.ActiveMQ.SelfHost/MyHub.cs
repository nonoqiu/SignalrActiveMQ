﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Messaging;
using System.Threading.Tasks;
using Signalr.ActiveMQ;

namespace SignalR.ActiveMQ.SelfHost.Signal.Class
{   
    public class chatHub : Hub
    {
        public void Send(string clientName, string message)
        {
            // _bus.Publish(new Message(clientName, "key", message));
            // Clients.All.broadcastMessage(clientName, message);
            Procucer.GetInstance().Send(message);
        }
        public override Task OnConnected()
        {
            Customer.Clients = this.Clients;
            return base.OnConnected();
        }
    }
}