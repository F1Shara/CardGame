using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class DeckBuilder
    {
        private enum Suit
        {
            Diamonds = '♦',
            Hearts = '♥',
            Spades = '♠',
            Clubs = '♣'
        }
        private string[] ranks = { "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
        private List<Card> cards = new List<Card>();       
        public List<Card> GetDeck()
        {
            Card newCard;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    switch (i)
                    {


                        case 0:
                            newCard = new Card(
                                (char)Suit.Hearts,
                                new Rank(ranks[j], j),
                                ConsoleColor.Red);
                            cards.Add(newCard);
                            break;
                        case 1:
                            newCard = new Card(
                                (char)Suit.Diamonds,
                                new Rank(ranks[j], j),
                                ConsoleColor.Blue);
                            cards.Add(newCard);
                            break;
                        case 2:
                            newCard = new Card(
                                (char)Suit.Spades,
                                new Rank(ranks[j], j),
                                ConsoleColor.White);
                            cards.Add(newCard);
                            break;
                        case 3:
                            newCard = new Card(
                                (char)Suit.Clubs,
                                new Rank(ranks[j], j),
                                ConsoleColor.Green);
                            cards.Add(newCard);
                            break;

                    }
                }
            }

            if (cards.Count != 0)
                return cards;
            else
                Console.Write("Колода не сгенерировалась !");

            return null;
        }
    }
}
