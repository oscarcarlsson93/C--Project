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
            Kordinater.X = 3;
            Kordinater.Y = 3;
        }

        public void SetRandomTargetPosition(Kordinat targetPosition)
        {
            Kordinater.X = targetPosition.X;
            Kordinater.Y = targetPosition.Y;    
        }
    }
}
