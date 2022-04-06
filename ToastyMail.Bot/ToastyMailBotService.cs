using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ToastyMail.Bot;

public class ToastyMailBotService : BackgroundService
{
    private readonly DiscordClient _client;

    public ToastyMailBotService(IConfiguration configuration)
    {
        var config = new DiscordConfiguration
        {
            Token = configuration["Discord:Token"],
            Intents = DiscordIntents.All,
            LoggerFactory = new LoggerFactory().AddSerilog(),
            MinimumLogLevel = LogLevel.Trace
        };

        _client = new DiscordClient(config);

        _client.MessageAcknowledged += async (client, args) =>
        {
            Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        };
        
        _client.GuildDownloadCompleted += async (client, args) =>
        {
            await client.Guilds[841890589640359946].Channels[880759197753548810].SendMessageAsync("e");
        };
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _client.ConnectAsync();
    }
}