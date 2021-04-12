using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Threading;
using System.Diagnostics;

namespace SnakeMyOwn
{
    class GameLoop
    {
        int direction = 0;
        public GameLoop()
        {

        }

        public Snake snake = new Snake();
        public Map map = new Map();

        //Gameloop
        public void MainLoop(int secondPerCycle)
        {
            Console.SetWindowSize(100, 50);

            map.BuildBarrier();
            map.AddFoodRandom();


            while (true)
            {
                CheckInput();
                Point moveAndGetLastPoint = snake.Controls(direction);
                map.GameField[moveAndGetLastPoint.X, moveAndGetLastPoint.Y] = "  ";

                if (snake.GetHeadLocation().X == map.GetFoodCoords().X || snake.GetHeadLocation().Y == map.GetFoodCoords().Y)
                {
                    map.AddFoodRandom();
                }

                DrawSnake();
                map.DrawGameField();

                Thread.Sleep(500);
            }
        }
        public void DrawSnake()
        {
            List<Point> body = snake.GetBody();

            map.GameField[snake.GetHeadLocation().X, snake.GetHeadLocation().Y] = "██";
            for (int i = 1; i < body.Count; i++)
            {               
                map.GameField[body[i].X, body[i].Y] = "██";
            }
        }

        //public void DrawSnake()
        //{
        //    map.GameField[snake.GetHeadLocation().X, snake.GetHeadLocation().Y] = "██";
        //}
        //map.GameField[snake.GetHeadLocation().X, snake.GetBody().First().Y] = "██";   

        public void CheckInput()
        {
            ConsoleKey key;
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        direction = 0;
                        break;
                    case ConsoleKey.D:
                        direction = 1;
                        break;
                    case ConsoleKey.S:
                        direction = 2;
                        break;
                    case ConsoleKey.A:
                        direction = 3;
                        break;
                }
            }
        }
    }
}
