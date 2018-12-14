using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LabyrinthGame
{
    class GameEngine
    {
        public List<Player> Players { get; set; } //Property som kan hålla en lista med spelare
        public List<Target> Targets { get; set; } //Property som kan hålla en lista med targets
        public SquareStatus[,] Grid { get; set; } // Property som kan hålla en labyrint
        public const int PointsToWin = 3;


        public GameEngine() //Konstruktor
        {
            InitializeGameWithStartMenue();

            SetStartingPositionsForPlayers();
            SetStartingPositionsForTargets();
        }

        private void InitializeGameWithStartMenue()
        {
            while (true)
            {
                ConsoleKeyInfo pressedKey = StartMenu.ShowStartMenueAndGetPressedKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        AddPlayersToGame(StartMenu.ShowSelectNumberOfPlayersMenuAndGetSelectedNumbersOfPlayers());
                        break;
                    case ConsoleKey.D2:
                        AddTargetsToGame(StartMenu.ShosSelectNumberOfTargetsMenueAndGetSelectedNumberOfTargets());
                        break;
                    case ConsoleKey.D3:
                        Grid = Labyrint.GetGrid(StartMenu.ShosSelectSizeMenueAndGetSelectedSizeAsKordinat());
                        break;
                    case ConsoleKey.D4:
                        return;
                }
            }
        }

        internal bool SomeoneHasWon()
        {
            return Players.Max(p => p.Points) == PointsToWin;
        }

        public void AddPlayersToGame(int numberOfPlayers)
        {
            Players = new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++)
                Players.Add(new Player());
        }

        public void AddTargetsToGame(int numberOfTargets)
        {
            Targets = new List<Target>();

            for (int i = 0; i < numberOfTargets; i++)
                Targets.Add(new Target());
        }

        public void SetStartingPositionsForTargets()
        {
            foreach (Target target in Targets)
                target.SetRandomTargetPosition(Grid, Players, Targets);
        }

        public void SetStartingPositionsForPlayers()
        {
            var startingPositions = new Kordinat[] { new Kordinat { X = 0, Y = 0 }, new Kordinat { X = Grid.GetLength(0) - 1, Y = Grid.GetLength(1) - 1 }, new Kordinat { X = 0, Y = Grid.GetLength(1) - 1 }, new Kordinat { X = Grid.GetLength(0) - 1, Y = 0 } };
            for (int i = 0; i < Players.Count; i++)
                Players[i].SetPlayerStartingPosition(startingPositions[i]);
        }

        public bool KeyPressIsValid(ConsoleKeyInfo keyPressed)
        {
            List<ConsoleKey> validKeys = new List<ConsoleKey>() { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow };
            return validKeys.Contains(keyPressed.Key);
        }

        public bool TryMovePlayer(Player player, ConsoleKeyInfo keyPressed)
        {
            Kordinat newKordinat = NewCoordinateFromKeyPress(player.Kordinater, keyPressed);// ta fram kordinaten spelaren försöker flytta till (Baserat på spelarens nuvarande position och vilken pil)

            if (CoordinatIsNOTValid(newKordinat))  // kolla om den nya kordinaten är utanför spelplanen 
                return false; // Inget mer utförs, dvs spelarens pjäs flyttas inte

            if (CoordinatIsEqualToTarget(newKordinat))
            {
                player.MovePlayerToCoordinate(newKordinat);
                PrintGrid(ConsoleColor.Green, player);
                Console.Beep(2000, 500);
                player.Points++;
                Target reachedTarget = Targets.Find(t => t.Kordinater.X == newKordinat.X && t.Kordinater.Y == newKordinat.Y);
                reachedTarget.SetRandomTargetPosition(Grid,Players,Targets);
                return false;
            }

            if (CoordinatIsNOTFree(newKordinat))  // kolla om den nya kordinaten är en vägg  
            {
                var tempColorStorage = player.Color;
                player.Color = ConsoleColor.Red;
                player.MovePlayerToCoordinate(newKordinat);

                PrintGrid(ConsoleColor.Red, player);
                Console.Beep(2000, 500);
                Console.Clear();
                Thread.Sleep(100);

                player.Color = tempColorStorage;
                player.MovePlayerToCoordinate(player.startingPosition);
                return false;
            }

            player.MovePlayerToCoordinate(newKordinat); // flytta spelaren

            return true; // Har vi kommit hit har vi lyckatas flytta spelaren, returnerar true
        }

        private bool CoordinatIsEqualToTarget(Kordinat newKordinat)
        {
            return Targets.Any(t => t.Kordinater.X == newKordinat.X && t.Kordinater.Y == newKordinat.Y);
        }

        private Kordinat NewCoordinateFromKeyPress(Kordinat kordinater, ConsoleKeyInfo keyPressed)
        {
            if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                kordinater.Y = kordinater.Y - 1;
            }
            if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                kordinater.Y = kordinater.Y + 1;
            }
            if (keyPressed.Key == ConsoleKey.RightArrow)
            {
                kordinater.X = kordinater.X + 1;
            }
            if (keyPressed.Key == ConsoleKey.LeftArrow)
            {
                kordinater.X = kordinater.X - 1;
            }
            return kordinater;
        }

        private bool CoordinatIsNOTValid(Kordinat kordinater)
        {
            if (Grid.GetLength(0) > kordinater.X && Grid.GetLength(1) > kordinater.Y && kordinater.X >= 0 && kordinater.Y >= 0)
                return false;
            return true;
        }

        private bool CoordinatIsNOTFree(Kordinat kordinater)
        {
            if (Grid[kordinater.X, kordinater.Y] == SquareStatus.wall)
                return true;
            return false;
        }

        public void PrintGrid(Player player)
        {
            PrintGrid(ConsoleColor.Gray, player);
        }

        public void PrintGrid(ConsoleColor color, Player player) // Målar upp rutnätet inkl spelare och mål (olika färger?)
        {
            PrintEngine.PrintGrid(color, Players, Targets, Grid, player);
        }
    }
}

