using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{

    class Labyrint
    {
        public SquareStatus[,] Grid { get; set; }

        internal static SquareStatus[,] GetNewTestGrid()
        {
            return new SquareStatus[7, 7] {
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free, SquareStatus.free }};
        }

        internal static SquareStatus[,] GetNewTestGridRectangle()
        {
            return new SquareStatus[2, 3] {
                { SquareStatus.free, SquareStatus.free, SquareStatus.free },
                { SquareStatus.free, SquareStatus.wall, SquareStatus.free }};
        }
    }
}
