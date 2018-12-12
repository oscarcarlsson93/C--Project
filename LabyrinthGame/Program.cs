using System;

namespace LabyrinthGame
{
    class Program
    {
        static void Main(string[] args)
        {
           // NewGame();
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
                    var keyPressed = Console.ReadKey(false);
                    game.TryMovePlayer(player, keyPressed);

                }


            }
        }
    }
}
