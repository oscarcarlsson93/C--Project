using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SetRandomTargetPosition(SquareStatus[,] grid, List<Player> players, List<Target> targets)
        {
            IEnumerable<Kordinat> occupiedCoordinates = players.Select(x => x.Kordinater);
            occupiedCoordinates = occupiedCoordinates.Concat(targets.Select(x => x.Kordinater));

            int randomX;
            int randomY;
            Random rnd = new Random();
            do
            {
                randomX = rnd.Next(1, grid.GetLength(0) - 1);
                randomY = rnd.Next(1, grid.GetLength(1) - 1); 
            } while (occupiedCoordinates.Any(cordinat => cordinat.X == randomX && cordinat.Y == randomY));

            Kordinater.X = randomX;
            Kordinater.Y = randomY;
        }
    }
}
