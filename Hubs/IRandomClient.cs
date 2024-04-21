namespace SignalRExample.Hubs
{
    public interface IRandomClient
    {
        Task DisplayRandom(int randNum);
    }
}
