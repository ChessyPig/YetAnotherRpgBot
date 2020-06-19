using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace YetAnotherRpgBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var discord = new DiscordClient(new DiscordConfiguration
            {
                Token = System.Environment.GetEnvironmentVariable("YarbToken"),
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "/yarb"
            });

            commands.RegisterCommands<CardCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
