using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class GameEngine
    {
        public List<Player> Players { get; set; } //Property som kan hålla en lista med spelare
        public List<Target> Targets { get; set; } //Property som kan hålla en lista med targets
        public SquareStatus[,] Grid { get; set; } // Property som kan hålla en labyrint

        public GameEngine() //Konstruktor
        {
            Grid = Labyrint.GetNewTestGrid(); ; //Initierar en ny labyrint 
            Players = new List<Player>(); // Initiera en tom lista med spelare
            Targets = new List<Target>(); // Initiera en tom lista med targets
        }

        public void AddNewPlayerToGame()
        {
            Players.Add(new Player()); // Skapar en ny spelare och lägger till den i listan med spelare
        }

        public void AddNewTargetToGame()
        {
            Targets.Add(new Target()); // Skapar en ny target och lägger till den i listan med target
        }

        public void TryMovePlayer(Player player, ConsoleKeyInfo keyPressed)
        {
            // Kolla att knapptryckningen var en av pilarna
            // ta fram kordinaten spelaren försöker flytta till (Baserat på spelarens nuvarande position och vilken pil)
            // kolla att den nya kordinaten inte är en vägg eller utanför spelplanen 
            // flytta spelaren
        }


        public void PrintGrid(SquareStatus[,] grid, List<Player> players, List<Target> targets) // Målar upp rutnätet inkl spelare och mål (olika färger?)
        {
            int x = 9;
            int y = 9;
            int pjäsX = 1;
            int pjäsY = 2;
                
            int cordY = 0;


            for (int i = 0; i < y * 2 + 1; i++)
            {
                int cordX = 0;

                string line = "";

                if (i == 0)
                    line += "╔";

                else if (i == y * 2)
                    line += "╚";

                else if (i % 2 != 0)
                {
                    Console.Write("║");
                }

                else if (i % 2 == 0)
                    line += "╠";


                for (int j = 0; j < x * 2 - 1; j++)
                {
                    if (i % 2 == 0)
                    {


                        if (j % 2 == 0)
                            line += "═══";

                        else
                        {
                            if (i == 0)
                                line += "╦";

                            else if (i == y * 2)
                                line += "╩";

                            else
                                line += "╬";
                        }

                    }
                    if (i % 2 != 0)
                    {

                        if (j % 2 == 0)
                        {
                            if (cordY == pjäsY && cordX == pjäsX)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" * ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            else
                                Console.Write("   ");
                            cordX++;
                        }
                        else
                        {
                            Console.Write("║");
                        }
                    }
                }
                if (i == 0)
                    line += "╗";

                else if (i == y * 2)
                    line += "╝";

                else if (i % 2 != 0)
                {
                    Console.Write("║");
                    cordY++;

                }

                else if (i % 2 == 0)
                    line += "╣";

                Console.WriteLine(line);

            }
        }
    }
}

