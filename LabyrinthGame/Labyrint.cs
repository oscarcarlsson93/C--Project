using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{

    class Labyrint
    {
        public SquareStatus[,] Grid { get; set; }






        internal static SquareStatus[,] GenerateBigGridFromFile()
        {
            string[] gridStringArray = System.IO.File.ReadAllLines("../../../grid.txt");

            SquareStatus[,] bigGrid = new SquareStatus[33, 33];
            int c = 0;
            foreach (var line in gridStringArray)
            {

                int r = 0;
                foreach (var zeroOrOne in line)
                {
                    if (zeroOrOne == '1')
                        bigGrid[c, r] = SquareStatus.wall;
                    else
                        bigGrid[c, r] = SquareStatus.free;

                    r++;
                }

                c++;
            }
            return bigGrid;
        }



        internal static SquareStatus[,] GetGrid(Kordinat cord)
        {
            SquareStatus[,] bigGrid = GenerateBigGridFromFile();

            SquareStatus[,] gameGrid = new SquareStatus[cord.X, cord.Y];

            Random rnd = new Random();
            int randomX = rnd.Next(0, 33 - cord.X);
            int randomY = rnd.Next(0, 33 - cord.Y);

            for (int i = 0; i < cord.X; i++)
            {
                for (int j = 0; j < cord.Y; j++)
                {
                    gameGrid[i, j] = bigGrid[i + randomX, j + randomY];
                }
            }
            gameGrid[0,0] = SquareStatus.free;
            gameGrid[0, cord.Y - 1] = SquareStatus.free;
            gameGrid[cord.X - 1, 0] = SquareStatus.free;
            gameGrid[cord.X - 1, cord.Y - 1] = SquareStatus.free;
            return bigGrid;
        }
    }
}
