using System;
using System.Collections.Generic;

namespace YetAnotherRpgBot
{
    public class CardDeck
    {
        private readonly List<PlayingCard> m_cardsRemaining = new List<PlayingCard>();
        private readonly Random m_Random = new Random();

        public CardDeck()
        {
            ResetDeck();
        }

        public void ResetDeck()
        {
            m_cardsRemaining.Clear();

            foreach (PlayingCardValue cardValue in Enum.GetValues(typeof(PlayingCardValue)))
            {
                foreach (PlayingCardSuit cardSuit in Enum.GetValues(typeof(PlayingCardSuit)))
                {
                    m_cardsRemaining.Add(new PlayingCard{Value = cardValue, Suit = cardSuit});
                }
            }
        }

        public PlayingCard DrawCard(PlayingCardSuit suit)
        {
            lock (m_cardsRemaining)
            {
                var possibleCards = m_cardsRemaining.FindAll(card => card.Suit == suit);
                if (possibleCards.Count < 1)
                {
                    return null;
                }         
                var cardPick = m_Random.Next(possibleCards.Count);
                var pickedCard = possibleCards[cardPick];
                m_cardsRemaining.Remove(pickedCard);
                return pickedCard;
            }
        }
    }
}