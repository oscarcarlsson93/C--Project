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
            game.AddNewPlayerToGame();
            game.AddNewTargetToGame();
        }

        private static void NewGame()
        {
            GameEngine game = new GameEngine();
            game.AddNewPlayerToGame();
            game.AddNewTargetToGame();


            while (true)  //GameLoop
            {
                foreach (Player player in game.Players)
                {
                    game.PrintGrid();
                    ConsoleKeyInfo keyPressed;
                    do
                    {
                        keyPressed = Console.ReadKey(false);
                    } while (!game.KeyPressIsValid(keyPressed));
                    

                    game.TryMovePlayer(player, keyPressed);
                }


            }
        }
    }
}
