using System;
using System.Globalization;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace YetAnotherRpgBot
{
    public class CardCommands
    {
        private readonly CardDeck m_CardDeck = new CardDeck();

        [Command("draw")]
        public async Task Draw(CommandContext context, string inputSuit)
        {
            var recasedInputSuit = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(inputSuit.ToLower());

            var suitExists = Enum.TryParse(typeof(PlayingCardSuit), recasedInputSuit, out var suit);

            if (!suitExists)
            {
                await context.RespondAsync($"I didn't recognise this as a valid card suit: {inputSuit}");
            }
            else
            {
                var card = m_CardDeck.DrawCard((PlayingCardSuit)suit);
                if (card == null)
                {
                    await context.RespondAsync($"There are no more {inputSuit} to draw!");
                }
                await context.RespondAsync($"Your card is {card.Value} of {card.Suit}");
            }
        }
        
        [Command("reset")]
        public async Task Reset(CommandContext context)
        {
            m_CardDeck.ResetDeck();
            await context.RespondAsync($"Card deck is reset and ready for more draws.");
        }
    }
}