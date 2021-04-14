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

                if (HitCollision())
                {
                    break;             
                }

                DrawSnake();
                map.DrawGameField();

                Thread.Sleep(200);
            }
            GameOver();
            Console.ReadKey();
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

        public void CheckInput()
        {
            ConsoleKey key;
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        if (direction != 2)
                        {
                            direction = 0;
                        }
                        break;
                    case ConsoleKey.D:
                        if (direction != 3)
                        {
                            direction = 1;
                        }
                        break;
                    case ConsoleKey.S:
                        if (direction != 0)
                        {
                            direction = 2;
                        }
                        break;
                    case ConsoleKey.A:
                        if (direction != 1)
                        {
                            direction = 3;
                        }
                        break;
                }
            }
        }

        public bool HitCollision()
        {
            Point foodCoord = map.GetFoodCoords();
            Point head = snake.GetHeadLocation();
            List<Point> body = snake.GetBody();

            if (head == foodCoord)
            {
                map.AddFoodRandom();
                snake.AddBody();
                return false;
            }
            else if (body.Contains(head))
            {              
                return true;
            }
            else if (map.Barrier.Contains(head))
            {          
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("you scored: " + snake.GetSize());
        }
    }
}
