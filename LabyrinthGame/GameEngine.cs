using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthGame
{
    class GameEngine
    {
        public List<Player> Players { get; set; } //Property som kan hålla en lista med spelare
        public List<Target> Targets { get; set; } //Property som kan hålla en lista med targets
        public Labyrint Grid { get; set; } // Property som kan hålla en labyrint

        public GameEngine() //Konstruktor
        {
            Grid = new Labyrint(); //Initierar en ny labyrint 
            Players = new List<Player>(); // Initiera en tom lista med spelare
            Targets = new List<Target>(); // Initiera en tom lista med targets
        }

        public void AddNewPlayerToGame()
        {
            Players.Add(new Player()); // Skapar en ny spelare och lägger till den i listan med spelare
        }

        internal void TryMovePlayer(Player player, ConsoleKeyInfo keyPressed)
        {
            
        }

        public void AddNewTargetToGame()
        {
            Targets.Add(new Target()); // Skapar en ny target och lägger till den i listan med target
        }


        public void PrintGrid() // Målar upp rutnätet inkl spelare och mål (olika färger?)
        {
        }
    }
}
