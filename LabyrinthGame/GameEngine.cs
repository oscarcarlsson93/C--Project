﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class GameEngine
    {
        public List<Player> Players { get; set; } //Property som kan hålla en lista med spelare
        public List<Target> Targets { get; set; } //Property som kan hålla en lista med targets
        public Labyrint Grid { get; set; } // Property som kan hålla en labyrint

        public GameEngine() //Konstruktor
        {
            Grid = new Labyrint(); //Initierar en ny labyrint 
            Players = new List<Player>(); // Initiera en tom lista med spelare
            Targets = new List<Target>(); // Initiera en tom lista med targets
        }

        public void AddNewPlayerToGame()
        {
            Players.Add(new Player()); // Skapar en ny spelare och lägger till den i listan med spelare
        }

        internal void TryMovePlayer(Player player, ConsoleKeyInfo keyPressed)
        {
            int x = 9;
            int y = 9;
            int pjäsX = 1;
            int pjäsY = 3;
            int cordX = 0;


            for (int i = 0; i < x * 2 + 1; i++)
            {
                int cordY = 0;

                string line = "";

                if (i == 0)
                    line += "╔";

                else if (i == x * 2)
                    line += "╚";

                else if (i % 2 != 0)
                {
                    Console.Write("║");
                    cordX++;
                }

                else if (i % 2 == 0)
                    line += "╠";


                for (int j = 0; j < y * 2 - 1; j++)
                {
                    if (i % 2 == 0)
                    {


                        if (j % 2 == 0)
                            line += "═══";

                        else
                        {
                            if (i == 0)
                                line += "╦";

                            else if (i == x * 2)
                                line += "╩";

                            else
                                line += "╬";
                        }





                    }
                    if (i % 2 != 0)
                    {

                        if (j % 2 == 0)
                        {
                            cordY++;
                            if (cordX == pjäsX && cordY == pjäsY)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" ֍ ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                                Console.Write("   ");
                        }
                        else
                        {
                            Console.Write("║");
                        }
                    }
                }
                if (i == 0)
                    line += "╗";

                else if (i == x * 2)
                    line += "╝";

                else if (i % 2 != 0)
                {
                    Console.Write("║");

                }

                else if (i % 2 == 0)
                    line += "╣";

                Console.WriteLine(line);

            }


        }

        public void AddNewTargetToGame()
        {
            Targets.Add(new Target()); // Skapar en ny target och lägger till den i listan med target
        }


        public void PrintGrid() // Målar upp rutnätet inkl spelare och mål (olika färger?)
        {
        }
    }
}

