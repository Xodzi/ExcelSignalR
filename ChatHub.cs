using Microsoft.AspNetCore.SignalR;
namespace ExcelSignalR
{
    public class ChatHub : Hub
    {
        public async Task Send(string username, string message)
        {
            // Отправка сообщения всем клиентам
            await this.Clients.All.SendAsync("Receive", message);
        }
    }
}
