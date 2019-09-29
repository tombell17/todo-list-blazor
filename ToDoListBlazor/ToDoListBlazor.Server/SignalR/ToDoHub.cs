using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Server.SignalR
{
    public class ToDoHub : Hub
    {
        private readonly static ConnectionMapping _connections = new ConnectionMapping();               
        
        public Task InitializeConnection(string userName)
        {
            string connectionId = Context.ConnectionId;

            _connections.Add(userName, connectionId);

            return Task.CompletedTask;
        }

        public static async Task PushToDo(ToDoViewModel toDo, string userName, IHubContext<ToDoHub> hubContext)
        {
            IEnumerable<string> userConnections = _connections.GetConnections(userName);            

            foreach (var connection in userConnections)
            {
                var serialized = JsonConvert.SerializeObject(toDo);
                await hubContext.Clients.Client(connection).SendAsync("PushToDo", serialized);
            }
        }

        public override Task OnDisconnectedAsync(System.Exception exception)
        {
            Clients.All.SendAsync("broadcastMessage", "system", $"{Context.ConnectionId} left the conversation");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
