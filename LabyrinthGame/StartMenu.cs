using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class StartMenu
    {
        public static GameEngine Menue(GameEngine game)
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
                        int numberOfPlayersSelected = SelectNumerOfPlayersMenue();
                        for (int i = 0; i < numberOfPlayersSelected; i++)
                            game.Players.Add(new Player());
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        return game;

                }
            }
        }

        private static int SelectNumerOfPlayersMenue()
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
            Console.WriteLine(Environment.NewLine + menu[0] + Environment.NewLine); // Prints menue title

            for (int i = 1; i <= menu.Count; i++) // Prints the menue options
            {
                Console.WriteLine($"{i}. {menu[i]}");
            }

            Console.WriteLine(Environment.NewLine + "Chose menu option by pressing corresponding number" + Environment.NewLine);

        }
    }
}
