using System.Threading.Tasks;
using DSharpPlus;

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

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("/yarb"))
                    await e.Message.RespondAsync("I can't actually do things yet, sorry");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
