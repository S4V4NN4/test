using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME;
using PLAYER;

namespace PROGRAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("3.ChaseData.txt", "PursuitLog.txt");
            game.Run();
        }
    }
}
