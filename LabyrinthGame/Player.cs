using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LabyrinthGame
{
    class Player : LabyrinthObject
    {
        public Kordinat startingPosition;
        public int Points { get; set; }

        public Player(bool defaultValues)
        {
            Points = 0;

            if (defaultValues)
            {
                Symbol = '@';
                Color = ConsoleColor.Blue;
            }
            else
            {

                // Sätta Foreground-color i stringen(Console.Foregroundcolor = ConsoleColor.Blue  == ConsoleColor.Blue.ToString();
                var ChoosePlayerColor = new List<string> { "Choose your color", ConsoleColor.White.ToString(), ConsoleColor.Yellow.ToString(), ConsoleColor.Cyan.ToString(), ConsoleColor.Magenta.ToString() };
                Console.WriteLine("NEW PLAYER");
                StartMenu.PrintMenue(ChoosePlayerColor);


                ConsoleKeyInfo pressedKey;
                do
                {
                    pressedKey = Console.ReadKey(true);
                } while (!StartMenu.ValidKeys().Exists(k => k == pressedKey.Key));
                int playerColor = int.Parse(pressedKey.KeyChar.ToString());
                Console.WriteLine($"You have chosen the color {ChoosePlayerColor[playerColor]}");

                Console.WriteLine("Choose your character");
                string playerSymbol = Console.ReadLine();
                char symbol = playerSymbol[0];
                Console.WriteLine($"You have chosen the character {symbol}");
                Thread.Sleep(1500);

                Color = Enum.Parse<ConsoleColor>(ChoosePlayerColor[playerColor]);
                Symbol = symbol;
            }

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
