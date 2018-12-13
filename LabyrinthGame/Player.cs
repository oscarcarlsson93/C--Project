using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class Player : LabyrinthObject
    {
        public Kordinat startingPosition;
        public int Tries { get; set; }
        public int Points { get; set; }

        public Player()
        {           
            Color = ConsoleColor.Blue;
            Tries = 0;
            Kordinater.X = 0;
            Kordinater.Y = 0;
            Symbol = '❶';
            Points = 0;
        }
        public void MovePlayerToCoordinate(Kordinat movedCoordinate)
        {
            Kordinater.X = movedCoordinate.X;
            Kordinater.Y = movedCoordinate.Y;
        }
        public void SetPlayerStartingPosition(Kordinat playerStartingPosition)
        {
            Kordinater.X = playerStartingPosition.X;
            Kordinater.Y = playerStartingPosition.Y;
        }
        public void SetPlayerSymbol(char playerSymbol)
        {
            Symbol = playerSymbol;
        }
        public void SetPlayerColor(ConsoleColor consoleColor)
        {
            Color = consoleColor;
        }
    }
}
