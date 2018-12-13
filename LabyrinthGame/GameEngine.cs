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

        public GameEngine() //Konstruktor
        {
            StartMenu.Menue(this);

            Players[0].SetPlayerStartingPosition(new Kordinat() { X = 0, Y = 0 });

            if (Players.Count < 1)
                Players[1].SetPlayerStartingPosition(new Kordinat() { X = Grid.GetLength(0) - 1, Y = Grid.GetLength(1) -1});
            if (Players.Count < 2)
                Players[2].SetPlayerStartingPosition(new Kordinat() { X = 0, Y = Grid.GetLength(1) - 1 });
            if (Players.Count < 3)
                Players[3].SetPlayerStartingPosition(new Kordinat() { X = Grid.GetLength(0) - 1, Y = 0 });

            Targets = new List<Target>(); // Initiera en tom lista med targets
            Targets.Add(new Target());
            foreach (Target target in Targets)
            {
                target.SetRandomTargetPosition(Grid);
            }
        }

        public void AddNewPlayerToGame()
        {
            Players.Add(new Player()); // Skapar en ny spelare och lägger till den i listan med spelare
        }

        public void AddNewTargetToGame()
        {
            Targets.Add(new Target()); // Skapar en ny target och lägger till den i listan med target
        }

        public bool KeyPressIsValid(ConsoleKeyInfo keyPressed)
        {
            List<ConsoleKey> validKeys = new List<ConsoleKey>() { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow };
            return validKeys.Contains(keyPressed.Key);
        }

        public bool TryMovePlayer(Player player, ConsoleKeyInfo keyPressed)
        {
            Kordinat newKordinat = NewCoordinateFromKeyPress(player.Kordinater, keyPressed);// ta fram kordinaten spelaren försöker flytta till (Baserat på spelarens nuvarande position och vilken pil)

            if (CoordinatIsValid(newKordinat) == false)  // kolla att den nya kordinaten inte är en vägg eller utanför spelplanen 
                return false;

            if (CoordinatIsEqualToTarget(newKordinat))
            {
                player.MovePlayerToCoordinate(newKordinat);
                for (int i = 0; i < 3; i++)
                {
                    PrintGrid(ConsoleColor.Green, player);
                    Console.Beep(2000, 500);
                    Console.Clear();
                    Thread.Sleep(100);
                }
                return false;
            }


            if (CoordinatIsFree(newKordinat) == false)  // kolla att den nya kordinaten inte är en vägg eller utanför spelplanen 
            {
                var tempColorStorage = player.Color;
                player.Color = ConsoleColor.Red;
                player.MovePlayerToCoordinate(newKordinat);
                for (int i = 0; i < 3; i++)
                {
                    PrintGrid(ConsoleColor.Red, player);
                    Console.Beep(2000, 500);
                    Console.Clear();
                    Thread.Sleep(100);

                }
                player.Color = tempColorStorage;
                player.MovePlayerToCoordinate(new Kordinat() { X = 0, Y = 0 });
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

        private bool CoordinatIsValid(Kordinat kordinater)
        {
            if (Grid.GetLength(0) > kordinater.X && Grid.GetLength(1) > kordinater.Y && kordinater.X >= 0 && kordinater.Y >= 0)
                return true;
            return false;
        }

        private bool CoordinatIsFree(Kordinat kordinater)
        {
            if (Grid[kordinater.X, kordinater.Y] == SquareStatus.wall)
                return false;
            return true;
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

