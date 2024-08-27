using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureLogging((context, logging) =>
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables().Build();
        LogManager.Setup().LoadConfigurationFromSection(config);
        logging.ClearProviders();
        logging.AddNLog(new NLogProviderOptions() { RemoveLoggerFactoryFilter = false });
    })
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
