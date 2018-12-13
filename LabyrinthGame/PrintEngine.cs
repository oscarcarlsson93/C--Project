using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabyrinthGame
{
    class PrintEngine
    {
        public static void PrintGrid(ConsoleColor color, List<Player> Players, List<Target> Targets, SquareStatus[,] Grid, Player player) // Målar upp rutnätet inkl spelare och mål (olika färger?)
        {
            Console.Clear();
            Console.ForegroundColor = color;

            int x = Grid.GetLength(0);
            int y = Grid.GetLength(1);
            

            List<LabyrinthObject> labyrinthObjects = new List<LabyrinthObject>();
            labyrinthObjects = labyrinthObjects.Concat(Players).Concat(Targets).ToList();


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
                                Console.ForegroundColor = color;
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
                PrintGameBar(Players, player);
        }
        public static void PrintGameBar(List<Player> Players, Player activePlayer)
        {
            Console.WriteLine();

            foreach (var player in Players)
            {
                if(player == activePlayer)
                    Console.ForegroundColor = player.Color;

                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(player.Symbol + " ");

                Console.ForegroundColor = ConsoleColor.Gray;

                if (player.Points == 1)
                    Console.Write(player.Points + " point \t" );
                else
                    Console.Write(player.Points + " points \t" );
            }
        }

    }
}
