using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    enum SquareStatus {wall, free};
    class Labyrint
    {
        public SquareStatus[,] Grid { get; set; }

        public Labyrint()
        {
            Grid = new SquareStatus[3, 3] {
                { SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free },
                { SquareStatus.free, SquareStatus.free, SquareStatus.free } };
        }
    }
}
