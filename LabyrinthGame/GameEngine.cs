using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool KeyPressIsValid(ConsoleKeyInfo keyPressed)
        {
            List<ConsoleKey> validKeys = new List<ConsoleKey>() { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow };
            return validKeys.Contains(keyPressed.Key);
        }

        public bool TryMovePlayer(Player player, ConsoleKeyInfo keyPressed)
        {
            if (!KeyPressIsValid(keyPressed)) // Kolla att knapptryckningen var en av pilarna
                return false;

            Kordinat newKordinat = NewCoordinateFromKeyPress(player.Kordinater, keyPressed);// ta fram kordinaten spelaren försöker flytta till (Baserat på spelarens nuvarande position och vilken pil)

            if (CoordinatIsValid(newKordinat) == false)  // kolla att den nya kordinaten inte är en vägg eller utanför spelplanen 
               return false;
            if (CoordinatIsFree(newKordinat) == false)  // kolla att den nya kordinaten inte är en vägg eller utanför spelplanen 
                return false;
                player.MovePlayerToCoordinate(newKordinat); // flytta spelaren

            return true; // Har vi kommit hit har vi lyckatas flytta spelaren, returnerar true
        }
        private Kordinat NewCoordinateFromKeyPress(Kordinat kordinater, ConsoleKeyInfo keyPressed)
        {
            if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                kordinater.Y = kordinater.Y - 1;
            }
            if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                kordinater.Y = kordinater.Y + 1;
            }
            if (keyPressed.Key == ConsoleKey.RightArrow)
            {
                kordinater.X = kordinater.X + 1;
            }
            if (keyPressed.Key == ConsoleKey.LeftArrow)
            {
                kordinater.X = kordinater.X - 1;
            }
            return kordinater;
        }

        private bool CoordinatIsValid(Kordinat kordinater)
        {
            if (!(Grid.GetLength(0) > kordinater.X && Grid.GetLength(0) > kordinater.Y) && kordinater.X >= 0 && kordinater.Y >= 0)
                return false;
            
            return true;
        }

        private bool CoordinatIsFree(Kordinat kordinater)
        {
            if (Grid[kordinater.X, kordinater.Y] == SquareStatus.wall)
                return false;
            return true;
        }

        public void PrintGrid() 
        {
            PrintGrid(Grid, Players, Targets);
        }

        public void PrintGrid(SquareStatus[,] grid, List<Player> players, List<Target> targets) // Målar upp rutnätet inkl spelare och mål (olika färger?)
        {
            Console.Clear();

            int x = grid.GetLength(0);
            int y = grid.GetLength(1);
           

            List<LabyrinthObject> labyrinthObjects = new List<LabyrinthObject>();
            labyrinthObjects = labyrinthObjects.Concat(players).Concat(targets).ToList();

                
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
                            if (labyrinthObjects.Any(o => o.Kordinater.X == cordX && o.Kordinater.Y == cordY))
                            {
                                var objectToPrint = labyrinthObjects.Find(o => o.Kordinater.X == cordX && o.Kordinater.Y == cordY);
                                Console.ForegroundColor = objectToPrint.Color;
                                Console.Write(" " + objectToPrint.Symbol + " ");
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

