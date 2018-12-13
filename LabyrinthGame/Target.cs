using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class Target : LabyrinthObject
    {

        public Target()
        {
            Name = "EndObjective";
            Color = ConsoleColor.Green;
            Symbol = '☺';
           
        }

        public void SetRandomTargetPosition(SquareStatus[,] grid)
        {
            Random rnd = new Random();
            int randomX = rnd.Next(1, grid.GetLength(0) - 1);
            int randomY = rnd.Next(1, grid.GetLength(1) - 1); ;

            Kordinater.X = randomX;
            Kordinater.Y = randomY;
        }
    }
}
