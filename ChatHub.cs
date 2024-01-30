using Microsoft.AspNetCore.SignalR;
namespace ExcelSignalR
{
    public class ChatHub : Hub
    {
        public async Task Send(string username, string message)
        {
            // Отправка сообщения всем клиентам
            await this.Clients.All.SendAsync("Receive", message, username);
        }
        public async Task SendPrivateMessage(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceivePrivateMessage", message);
        }
        public async Task SendJsonChunk(string chunk, bool startNewMessage)
        {
            // Передача данных всем подключенным клиентам
            await Clients.All.SendAsync("ReceiveJsonChunk", chunk, startNewMessage);
        }


    }
}
