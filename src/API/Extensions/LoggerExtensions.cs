using Infrastructure.Logging;
using Serilog;

namespace API.Extensions;

public static class LoggerExtensions
{
    public static void AddLoggerServices(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder().AddJsonFile("loggersettings.json").Build();
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

        
    }
}