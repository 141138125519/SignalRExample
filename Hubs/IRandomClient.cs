namespace SignalRExample.Hubs
{
    public interface IRandomClient
    {
        Task ReceiveRandom(int randNum);
    }
}
