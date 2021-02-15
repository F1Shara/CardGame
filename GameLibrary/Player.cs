using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Player
    {
        public Player (string name)
        {
            Table = new List<Card>();
            Hand = new List<Card>();

            Turn = false;
            Name = name;
        }
        public List<Card> Hand { get; set; }
        public List<Card> Table { get; set; }
        public bool Turn { get; set; }
        public string Name { get; set; }
        public bool Action { get; set; }
        public int DefaultHandSize
        {
            get { return 6; }            
        }


        public void DisplayHand()
        {
            foreach (var item in Hand)
            {                
                item.Display();
            }
        }
        public void DisplayTable()
        {
            foreach (var item in Table)
            {
                item.Display();
            }
        }
        public List<string> GetTableNames()
        {
            List<string> name = new List<string>();
            foreach (var item in Table)
            {
                name.Add(item.Rank.Name);
            }
            return name;
        }
        public List<int> GetTableValue()
        {
            List<int> value = new List<int>();
            foreach (var item in Table)
            {
                value.Add(item.Rank.Value);
            }
            return value;

        }
    }
}
