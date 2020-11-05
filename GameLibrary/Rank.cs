using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Rank
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        public Rank(string n, int v)
        {
            Name = n;
            Value = v;
        }
    }
}
