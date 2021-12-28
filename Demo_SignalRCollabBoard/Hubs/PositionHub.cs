using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Demo_SignalRCollabBoard.Hubs
{
    public class PositionHub : Hub
    {
        public async Task SendPosition(int left, int top)
        {
            await Clients.Others.SendAsync("ReceivePosition", left, top);
        }
    }
}
