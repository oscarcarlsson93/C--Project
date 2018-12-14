using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LabyrinthGame
{
    class Player : LabyrinthObject
    {
        public Kordinat startingPosition;
        public int Tries { get; set; }
        public int Points { get; set; }

        public Player()
        {                                       // Sätta Foreground-color i stringen(Console.Foregroundcolor = ConsoleColor.Blue  == ConsoleColor.Blue.ToString();
            var ChoosePlayerColor = new List<string> { "Choose your color", ConsoleColor.White.ToString(), ConsoleColor.Yellow.ToString(), ConsoleColor.Cyan.ToString(), ConsoleColor.Magenta.ToString() };
            
            StartMenu.PrintMenue(ChoosePlayerColor);


            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey(true);
            } while (!(pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.D4));
            int playerColor = int.Parse(pressedKey.KeyChar.ToString());
            Console.WriteLine($"You have chosen the color {ChoosePlayerColor[playerColor]}");

            Console.WriteLine("Choose your character");
            string playerSymbol = Console.ReadLine();
            char symbol = playerSymbol[0];
            Console.WriteLine($"You have chosen the character {symbol}");
            Thread.Sleep(1500);
            

            Color = Enum.Parse<ConsoleColor>(ChoosePlayerColor[playerColor]);
            Tries = 0;                       
            Symbol = symbol;
            Points = 0;
        }
        public void MovePlayerToCoordinate(Kordinat movedCoordinate)
        {
            Kordinater.X = movedCoordinate.X;
            Kordinater.Y = movedCoordinate.Y;
        }
        public void SetPlayerStartingPosition(Kordinat playerStartingPosition)
        {
            startingPosition.X = playerStartingPosition.X;
            startingPosition.Y = playerStartingPosition.Y;
            MovePlayerToCoordinate(startingPosition);
        }
        public void SetPlayerSymbol(char playerSymbol)
        {
            Symbol = playerSymbol;
        }
        public void SetPlayerColor(ConsoleColor consoleColor)
        {
            Color = consoleColor;
        }
        public void ResetPlayerPosition()
        {
            Kordinater.X = startingPosition.X;
            Kordinater.Y = startingPosition.Y;
        }
    }
}
