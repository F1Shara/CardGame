﻿using System;
using System.Collections.Generic;
using System.Text;
using GameLibrary;

namespace CardGame
{
    public class GameController
    {
        // Data about all game items (player, deck, card, etc)
        private GameField field;
        const int HandSize = 6;
        private void SortDeck(List<Card> deck)
        {
            Random rng = new Random();
            int n = field.deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = field.deck[k];
                field.deck[k] = field.deck[n];
                field.deck[n] = value;
            }
        }
        // Create new game
        protected internal void StartGame()
        {          

            Console.Write("Введите имя игрока 1: ");
            string player1Name = Console.ReadLine();
            Console.Write("Введите имя игрока 2: ");
            string player2Name = Console.ReadLine();

            field = new GameField(player1Name, player2Name);
            SortDeck(field.deck);
            
            // Give full hand to both player
            foreach (var item in field.players)
            {
                GetCards(HandSize, item);
            }
            CheckTurn(true);
            DisplayTable();
        }
        private void DisplayDeckCount()
        {
            Console.Write($"Колода: {field.deck.Count}\t");            
        }
        // Display all game data
        private void DisplayTable()
        {
            Console.Clear();
            bool player1 = true;
            string currentPlayer = null;
            
            foreach (var item in field.players)
            {
                if (item.Turn)
                    currentPlayer = item.Name;

            }            
            foreach (var item in field.players)
            {
                Console.Write($"Рука играка {item.Name}: ");
                item.DisplayHand();
                if (player1)
                {

                    Console.Write("\n\n\t\t");
                    field.players[0].DisplayTable();
                    Console.Write("\n");
                    DisplayDeckCount();
                    Console.Write($"\t\t Ходит: {currentPlayer}");
                    Console.Write("\n\t\t");
                    field.players[1].DisplayTable();
                    Console.Write("\n\n");

                    player1 = false;
                }

            }
            player1 = true;
        }
        // Add card to hand from dack
        private void GetCards(int count, Player player)
        {
           
            if (field.deck.Count != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    player.Hand.Add(field.deck[0]);
                    field.deck.RemoveAt(0);
                }                
            }            
        }        
        // Switch active player
        private void CheckTurn()
        {
                foreach (var item in field.players)
                {
                    item.Turn = !item.Turn;
                }
        }
        // Switch active player
        private void CheckTurn(bool firstTurn)
        {
            if (firstTurn)
            {
                int value = 10;
                Player player = null;
                foreach (var item in field.players)
                {
                    foreach (var card in item.Hand)
                    {
                        if (card.Rank.Value <= value)
                        {
                            value = card.Rank.Value;
                            player = item;
                        }
                    }
                }
                player.Turn = true;
                player.Action = true;                
            }
            else
            {
                foreach (var item in field.players)
                {
                    item.Turn = !item.Turn;                    
                }
            }
        }
        // Main method in which the game take place 
        protected internal void Play()
        {
            bool game = true;
            int currentCardValue = 0;
            char currentCardSuit = ' ';
            int cardIndex = 0;
            string console = null;
            while (game)
            {
                foreach (var item in field.players)
                {
                    // Active player move
                    if (item.Turn)
                    {
                        // Throws up or fights back
                        if (item.Action)
                        {
                            if (item.Table.Count == 0)
                            {
                                console = Console.ReadLine();                               
                                {
                                    cardIndex = Convert.ToInt32(console);
                                    item.Table.Add(item.Hand[cardIndex - 1]);
                                    currentCardValue = item.Hand[cardIndex - 1].Rank.Value;
                                    currentCardSuit = item.Hand[cardIndex - 1].Suit;
                                    item.Hand.RemoveAt(cardIndex - 1);
                                    CheckTurn();
                                    DisplayTable();
                                }
                            }
                            else
                            {
                                console = Console.ReadLine();
                                if (console == " ")
                                {
                                    ConverActionStatus();
                                    LightsOut();
                                    CheckTurn();
                                    DisplayTable();
                                }
                                else
                                {                                    
                                    {
                                        cardIndex = Convert.ToInt32(console);
                                        if (field.players[0].GetTableNames().Contains(item.Hand[cardIndex - 1].Rank.Name) || field.players[1].GetTableNames().Contains(item.Hand[cardIndex - 1].Rank.Name))
                                        {
                                            item.Table.Add(item.Hand[cardIndex - 1]);
                                            currentCardValue = item.Hand[cardIndex - 1].Rank.Value;
                                            currentCardSuit = item.Hand[cardIndex - 1].Suit;
                                            item.Hand.RemoveAt(cardIndex - 1);
                                            CheckTurn();
                                            DisplayTable();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            console = Console.ReadLine();
                            if (console == " ")
                            {
                                TakeTable(item);
                                CheckTurn();
                                DisplayTable();
                            }
                            else
                            {                                
                                {
                                    int index = Convert.ToInt32(console);
                                    if (currentCardValue < item.Hand[index - 1].Rank.Value && currentCardSuit == item.Hand[index - 1].Suit)
                                    {
                                        item.Table.Add(item.Hand[index - 1]);
                                        item.Hand.RemoveAt(index - 1);
                                        CheckTurn();
                                        DisplayTable();
                                    }
                                }
                            }


                        }
                    }
                }
            }
        }
        // Reset the table and draw card to a full hand
        private void LightsOut()
        {
            foreach (var item in field.players)
            {                
                item.Table.Clear();
                if (HandSize - item.Hand.Count > 0)
                    GetCards(HandSize - item.Hand.Count, item);
            }
        }
        // Add all card on table to player hand
        private void TakeTable(Player player)
        {            
            foreach (var item in field.players)
            {
                foreach (var card in item.Table)
                {
                    player.Hand.Add(card);
                }
                item.Table.Clear();

                if (HandSize - item.Hand.Count > 0)
                    GetCards(HandSize - item.Hand.Count, item);
            }
           
        }
        // Switch throws player 
        private void ConverActionStatus()
        {
            foreach (var item in field.players)
            {
                item.Action = !item.Action;
            }
        }       
    }
}
