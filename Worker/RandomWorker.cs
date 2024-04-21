using Microsoft.AspNetCore.SignalR;
using SignalRExample.Hubs;

namespace SignalRExample.Worker
{
    public class RandomWorker(
        ILogger<RandomWorker> logger,
        IHubContext<RandomHub, IRandomClient> randomHub
        ) : BackgroundService
    {
        private readonly Random random = new();
        private readonly ILogger<RandomWorker> _logger = logger;

        /// <summary>
        /// To inject the Hub into our worker this IHubContext is needed,
        /// we can't directly inject IRandomClient or RandomHub
        /// </summary>
        private readonly IHubContext<RandomHub, IRandomClient> _randomHub = randomHub;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Start Worker");
            while (!stoppingToken.IsCancellationRequested)
            {
                await GenerateRandom();
                await Task.Delay(1000, stoppingToken);
            }
        }

        /// <summary>
        /// Generates a random number and then sends that to connected clients
        /// using signalR Hub
        /// </summary>
        /// <returns></returns>
        private async Task GenerateRandom()
        {
            try
            {
                await _randomHub.Clients.All.DisplayRandom(random.Next(0, 100_000));
            }
            catch (Exception ex)
            {
                _logger.LogError("GenerateRandom | Something went wrong: {ex}", ex);
            }
        }
    }
}
