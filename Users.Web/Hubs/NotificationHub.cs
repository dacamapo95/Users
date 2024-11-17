using Microsoft.AspNetCore.SignalR;

namespace Users.Web.Hubs;

public class NotificationHub : Hub
{

    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
