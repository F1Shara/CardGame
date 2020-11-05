using System;
using System.Collections.Generic;
using GameLibrary;

namespace CardGame
{
    class Program
    {       
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            
            controller.StartGame();            
            controller.Play();

        }


    }
}
