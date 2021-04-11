using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;


namespace SnakeMyOwn
{
    class Program
    {
        static void Main(string[] args)
        {
            // ██ = snakebody
            // ░░ = barrier
            GameLoop gameLoop = new GameLoop();
            gameLoop.MainLoop(1);

        }
    }
}