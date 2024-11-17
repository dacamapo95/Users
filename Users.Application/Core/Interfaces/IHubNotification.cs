namespace Users.Application.Core.Interfaces;
public interface IHubNotification
{
    Task SendNotification(string message);

    Task OnConnectedAsync();
}
