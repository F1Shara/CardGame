using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{           
    public class Card
    {
        public char Suit { get; private set; }
        public Rank Rank { get; private set; }
        public bool Hide  { get; set; }        

        public ConsoleColor Color { get; private set; }

        public void Display()
        {
            Console.ForegroundColor = Color;
            Console.Write($"{Rank.Name}{Suit} ");
            Console.ResetColor();
        }

        public Card (char s, Rank r, ConsoleColor c)
        {
            Hide = false;
            Suit = s;
            Rank = r;       
            Color = c;
        }

    }
}
