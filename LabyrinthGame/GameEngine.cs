using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class GameEngine
    {
        public void PrintGrid() // Målar upp rutnätet inkl spelare och mål (olika färger?)
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
    }
}

