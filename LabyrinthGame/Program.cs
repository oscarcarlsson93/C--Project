using System;

namespace LabyrinthGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPrintGrid();
            // NewGame();
        }

        private static void TestPrintGrid()
        {
            GameEngine game = new GameEngine();
            game.PrintGrid();
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

                    var keyPressed = Console.ReadKey(false);
                    game.TryMovePlayer(player, keyPressed);

                }


            }
        }
    }
}
