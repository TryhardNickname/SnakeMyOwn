using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;


namespace SnakeMyOwn
{
    class Map
    {
        public static int GameSize = 45;
        public string[,] GameField = new string[GameSize, GameSize];
        public List<Point> Barrier = new List<Point>();
        Point foodCoords;

        public Map()
        {

        }

        public void BuildBarrier()
        {
            for (int i = 0; i < GameSize; i++)
            {
                GameField[0, i] = "░░";  // Top
                Barrier.Add(new Point(0, i));

                GameField[GameSize - 1, i] = "░░";  // Bottom
                Barrier.Add(new Point(GameSize - 1, i));

                GameField[i, 0] = "░░";  // Left
                Barrier.Add(new Point(i, 0));

                GameField[i, GameSize - 1] = "░░";  // Right
                Barrier.Add(new Point(i, GameSize - 1));

            }
        }

        public void DrawGameField()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < GameSize; i++)
            {
                for (int j = 0; j < GameSize; j++)
                {
                    if (GameField[i, j] == null || GameField[i, j] == "  ")
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(GameField[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public void AddFoodRandom()
        {
            Random rand = new Random();
            // ❤

            foodCoords = new Point(rand.Next(2, GameSize - 2), rand.Next(2, GameSize - 2));
            while (GameField[foodCoords.X, foodCoords.Y] == "██" && GameField[foodCoords.X, foodCoords.Y] == "░░")
            {
                foodCoords = new Point(rand.Next(2, GameSize - 2), rand.Next(2, GameSize - 2));
            }
                
            GameField[foodCoords.X, foodCoords.Y] = "❤ ";
        }

        public Point GetFoodCoords()
        {
            return foodCoords;
        }
    }
}
