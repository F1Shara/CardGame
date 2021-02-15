using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class GameField
    {
        public GameField(string name1, string name2)
        {
            deck = deckBuilder.GetDeck();                        
            SortDeck();            
            TrumpCard = deck[deck.Count - 1];
            SetTrump();
            TrumpCard.Display();            
            players.Add(new Player(name1));
            players.Add(new Player(name2));

        }
        public List<Card> deck = new List<Card>();
        public List<Player> players = new List<Player>();
        public DeckBuilder deckBuilder = new DeckBuilder();
        public Card TrumpCard {get;}
        private void SortDeck()
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }
        // Add more value to Trump cards.
        private void SetTrump()
        {
            foreach (var item in deck)
            {
                if(item.Suit == TrumpCard.Suit)
                {
                    item.Rank.Value += 10;
                }
            }
        }
        // For test
        private void DisplayRunkValue()
        {
            foreach (var item in deck)
            {
                item.Display();
                Console.Write($"={item.Rank.Value}");
            }
        }
    }
}
