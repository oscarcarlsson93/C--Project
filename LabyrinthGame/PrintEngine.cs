using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LabyrinthGame
{
    class PrintEngine
    {
        public static void PrintGrid(ConsoleColor color, List<Player> Players, List<Target> Targets, SquareStatus[,] Grid, Player player) // Målar upp rutnätet inkl spelare och mål (olika färger?)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = color;

            int labyrinthWidth = Grid.GetLength(0);
            int labyrinthHeight = Grid.GetLength(1);

            List<LabyrinthObject> labyrinthObjects = MergePlayersAndTargets(Players, Targets);

            int cordY = 0;

            for (int lineToPrint = 0; lineToPrint <= labyrinthHeight * 2; lineToPrint++)
            {
                int cordX = 0;
                string printLine = "";

                printLine = setLeftSideOfGrid(labyrinthHeight, lineToPrint, printLine);

                for (int xCoordinatOnLine = 0; xCoordinatOnLine < labyrinthWidth * 2 - 1; xCoordinatOnLine++)
                {
                    printLine = setHorisontellLabyrinthWalls(printLine, lineToPrint, xCoordinatOnLine, labyrinthHeight);


                    if (lineToPrint % 2 != 0)
                        cordX = setVerticalLabyrinthWalls(xCoordinatOnLine, labyrinthObjects, cordX, cordY, color);
                }

                if (lineToPrint == 0)
                    printLine += "╗";

                else if (lineToPrint == labyrinthHeight * 2)
                    printLine += "╝";

                else if (lineToPrint % 2 != 0)
                {
                    Console.Write("║");
                    cordY++;
                }

                else if (lineToPrint % 2 == 0)
                    printLine += "╣";

                Console.WriteLine(printLine);
            }
            PrintGameBar(Players, player);
        }

        private static int setVerticalLabyrinthWalls(int xCoordinatOnLine, List<LabyrinthObject> labyrinthObjects, int cordX, int cordY, ConsoleColor color)
        {
            if (xCoordinatOnLine % 2 == 0)
            {
                if (labyrinthObjects.Any(o => o.Kordinater.X == cordX && o.Kordinater.Y == cordY))
                    printLabyrithObjectOrEmptySpace(labyrinthObjects, cordX, cordY, color);

                else
                    Console.Write("   ");

                cordX++;
            }
            else
                Console.Write("║");

            return cordX;
        }

        private static void printLabyrithObjectOrEmptySpace(List<LabyrinthObject> labyrinthObjects, int cordX, int cordY, ConsoleColor color)
        {
            var objectToPrint = labyrinthObjects.Find(o => o.Kordinater.X == cordX && o.Kordinater.Y == cordY);
            Console.ForegroundColor = objectToPrint.Color;
            Console.Write(" " + objectToPrint.Symbol + " ");
            Console.ForegroundColor = color;
        }

        private static string setHorisontellLabyrinthWalls(string printLine, int lineToPrint, int xCoordinatOnLine, int labyrinthHeight)
        {
            if (lineToPrint % 2 == 0)
            {
                if (xCoordinatOnLine % 2 == 0)
                    printLine += "═══";

                else
                {
                    if (lineToPrint == 0)
                        printLine += "╦";

                    else if (lineToPrint == labyrinthHeight * 2)
                        printLine += "╩";

                    else
                        printLine += "╬";
                }

            }
            return printLine;
        }

        private static string setLeftSideOfGrid(int labyrinthHeight, int lineToPrint, string printLine)
        {
            if (lineToPrint == 0)
                printLine += "╔";

            else if (lineToPrint == labyrinthHeight * 2)
                printLine += "╚";

            else if (lineToPrint % 2 != 0)
                Console.Write("║");

            else if (lineToPrint % 2 == 0)
                printLine += "╠";

            return printLine;
        }

        private static List<LabyrinthObject> MergePlayersAndTargets(List<Player> players, List<Target> targets)
        {
            List<LabyrinthObject> labyrinthObjects = new List<LabyrinthObject>();
            return labyrinthObjects.Concat(players).Concat(targets).ToList();
        }

        public static void PrintGameBar(List<Player> Players, Player activePlayer)
        {
            Console.WriteLine();

            foreach (var player in Players)
            {
                if (player == activePlayer)
                    Console.ForegroundColor = player.Color;

                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(player.Symbol + " ");

                Console.ForegroundColor = ConsoleColor.Gray;

                if (player.Points == 1)
                    Console.Write(player.Points + " point \t");
                else
                    Console.Write(player.Points + " points \t");

            }

            Console.ForegroundColor = activePlayer.Color;
            Console.WriteLine();
            Console.WriteLine(new string('=', Players.Count * 16));
            Console.Write(activePlayer.Symbol);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" : It's your turn!");
        }
        public static void PrintWinScreen(List<Player> players)
        {
            Console.Clear();
            int winPoints = players.Max(p => p.Points);
            Player winner = players.Find(p => p.Points == winPoints);

            foreach (var player in players)
            {
                Console.ForegroundColor = player.Color;
                Console.Write(player.Symbol);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (player.Points == 1)
                    Console.Write(": " + player.Points + " point \t");
                else
                    Console.Write(": " + player.Points + " points \t");
            }
            Console.WriteLine("\n\n\n\n\n");
            Console.ForegroundColor = winner.Color;
            for (int i = 0; i < 200; i++)
            {
                Console.Write(winner.Symbol + "    ");
            }
            Console.WriteLine("\n\n\n\t\t\t\t" + winner.Symbol);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\tYou are the champion!");
            Console.WriteLine();

            Thread.Sleep(5000);


        }
    }
}
