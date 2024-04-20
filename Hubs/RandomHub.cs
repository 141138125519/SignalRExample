using Microsoft.AspNetCore.SignalR;

namespace SignalRExample.Hubs
{
    public class RandomHub : Hub<IRandomClient>
    {
        public async Task SendRandom(int randNum)
            => await Clients.All.ReceiveRandom(randNum);
    }
}
