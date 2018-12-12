using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class Player : LabyrinthObject
    {
        
        public int Tries { get; set; }

        public Player()
        {
            Name = "Player 1";
            Color = ConsoleColor.Blue;
            Tries = 0;
            Kordinater.X = 0;
            Kordinater.Y = 0;
            Symbol = '*';

        }
    }
}
