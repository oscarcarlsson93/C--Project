using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LabyrinthGame
{
    class StartMenu
    {

        public static ConsoleKeyInfo ShowStartMenueAndGetPressedKey()
        {
            var StartMenueList = new List<string> { "Start menue", $"Select number of players", "Select grid size", "Start game" };
            PrintMenue(StartMenueList);
            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey();
            } while (!(pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.D3));

            return pressedKey ;
        }

        public static Kordinat SelectLabyrintSize()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Labyrint Height and Width can not be larger than 25 or lesser than 5.\nEnter labyrint height and width below separated by a comma (exampel '9,12')");
                Console.Write(Environment.NewLine + "Enter labyrint size: "); // Prints menue title

                string userInput = Console.ReadLine();

                if (Regex.IsMatch(userInput, "^([5-9]|[1][0-9]|[2][0-5]),([5-9]|[1][0-9]|[2][0-5])$"))
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

            for (int i = 1; i < menu.Count; i++) // Prints the menue options
            {
                Console.WriteLine($"{i}. {menu[i]}");
            }

            Console.WriteLine(Environment.NewLine + "Chose menu option by pressing corresponding number" + Environment.NewLine);

        }
    }
}
