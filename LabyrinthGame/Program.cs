using System;

namespace LabyrinthGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            //TestPrintGrid();
            NewGame();
        }

        private static void TestPrintGrid()
        {

            GameEngine game = new GameEngine();
        }

        private static void NewGame()
        {
            while (true)
            {

            GameEngine game = new GameEngine();


            while (game.SomeoneHasWon() == false)  //GameLoop
            {
                foreach (Player player in game.Players)
                {
                    game.PrintGrid(player);
                    ConsoleKeyInfo keyPressed;
                    do
                    {
                        keyPressed = Console.ReadKey(false);
                    } while (!game.KeyPressIsValid(keyPressed));
                    game.TryMovePlayer(player, keyPressed);

                    if (game.SomeoneHasWon())
                    {
                        PrintEngine.PrintWinScreen(game.Players);
                        break;
                    }
                }
            }
            }
        }
    }
}
