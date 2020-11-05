using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Table
    {
        public List<Card> player1;
        public List<Card> player2;

        public Table()
        {
            player1 = new List<Card>();
            player2 = new List<Card>();
        }
    }
}
