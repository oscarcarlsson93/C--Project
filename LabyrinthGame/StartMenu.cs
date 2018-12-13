using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LabyrinthGame
{
    class StartMenu
    {
        public static void Menue(GameEngine game)
        {
            ConsoleColor.Red.ToString();

            var StartMenueList = new List<string> { "Start menue", $"Select number of players (now {game.Players.Count} players)", "Select grid size", "Start game" };

            PrintMenue(StartMenueList);
            var pressedKey = Console.ReadKey();

            while (true)
            {
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        var players = new List<Player>();
                        int numberOfPlayersSelected = SelectNumerOfPlayersMenue();
                        for (int i = 0; i < numberOfPlayersSelected; i++)
                        {
                            players.Add(new Player());
                        }
                        game.Players = players;
                        break;
                    case ConsoleKey.D2:
                        Kordinat selectedSize = SelectLabyrintSize();
                        game.Grid = Labyrint.GetGrid(selectedSize);
                        break;
                    case ConsoleKey.D3:
                        return;
                }
            }
        }

        private static Kordinat SelectLabyrintSize()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Labyrint Height and Width can not be larger than 25 or lesser than 5.\nEnter labyrint height and width below separated by a comma (exampel '9,12')");
                Console.Write(Environment.NewLine + "Enter labyrint size: "); // Prints menue title

                string userInput = Console.ReadLine();

                if (Regex.IsMatch(userInput, "^[5-25]?,[5-25]$"))
                {
                    var userInputSplitted = userInput.Split(',');
                    Kordinat selectedGridSize = new Kordinat();
                    selectedGridSize.X = int.Parse(userInputSplitted[0]);
                    selectedGridSize.Y = int.Parse(userInputSplitted[1]);
                    return selectedGridSize;
                }
            }
        }

        public static int SelectNumerOfPlayersMenue()
        {

            var selectNumberOfPlayersMenu = new List<string> { "Select the numbers of players", "1 player", "2 players", "3 players", "4 players" };

            PrintMenue(selectNumberOfPlayersMenu);
            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey();
            } while (!(pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.D4));

            return int.Parse(pressedKey.KeyChar.ToString());
        }

        public static void PrintMenue(List<string> menu)
        {
            Console.Clear();
            Console.WriteLine(Environment.NewLine + menu[0] + Environment.NewLine); // Prints menue title

            for (int i = 1; i <= menu.Count; i++) // Prints the menue options
            {
                Console.WriteLine($"{i}. {menu[i]}");
            }

            Console.WriteLine(Environment.NewLine + "Chose menu option by pressing corresponding number" + Environment.NewLine);

        }
    }
}
