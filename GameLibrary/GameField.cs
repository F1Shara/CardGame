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
            players.Add(new Player(name1));
            players.Add(new Player(name2));

        }
        public List<Card> deck = new List<Card>();        
        public List<Player> players = new List<Player>();        
        public DeckBuilder deckBuilder = new DeckBuilder();    
                
    }
}
