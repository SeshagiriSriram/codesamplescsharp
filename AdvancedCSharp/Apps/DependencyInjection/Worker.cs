using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace DependencyInjection
{
    // Both MessageWriter and Logger are injected
    // via Constructor Injection :-) 
    public sealed class Worker(ILogger<Worker> _logger,IMessageWriter messageWriter ) : Microsoft.Extensions.Hosting.BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //_logger.LogCritical($"1->Logger category: {_logger.GetType().FullName}");
            //_logger.LogCritical($"2->Logger category: {typeof(Worker).FullName}");
            while (!stoppingToken.IsCancellationRequested)
            {
                string message = $"Worker running at: {DateTimeOffset.Now}";
                messageWriter.Write(message);
                _logger.LogInformation("Worker running at: {time}",DateTimeOffset.Now);
                //Log4Net Debug now no longer seems to work.... 
                //_logger.LogDebug("**** And this is an example of a debug message");
                _logger.LogWarning("**** This is just a warning");
                _logger.LogCritical("**** And a real Critical Error");
                _logger.LogError("**** and Our Program crashed");
                await Task.Delay(1_000, stoppingToken);
            }
        }
    }
}