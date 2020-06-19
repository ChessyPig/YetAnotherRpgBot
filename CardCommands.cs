using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace YetAnotherRpgBot
{
    public class CardCommands
    {
        [Command("draw")]
        public async Task Draw(CommandContext context, string suit, bool reset = false)
        {
            await context.RespondAsync($"👋 Hi, {context.User.Mention}! I'm afraid I can't draw {suit} cards yet.");
        }
    }
}