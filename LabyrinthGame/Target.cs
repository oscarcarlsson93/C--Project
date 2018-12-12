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
            Color = ConsoleColor.Red;
            Symbol = 'X';
            Kordinater.X = 1;
            Kordinater.Y = 1;
        }
    }
}
