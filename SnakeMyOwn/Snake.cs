using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace SnakeMyOwn
{
    class Snake
    {
        int Size;
        Point HeadLocation;
        List<Point> SnakeBody;
        Random random = new Random();

        public Snake()
        {
            Size = 1;
            HeadLocation = new Point(random.Next(2, Map.GameSize - 2), random.Next(2, Map.GameSize - 2));
            SnakeBody = new List<Point>();
            SnakeBody.Add(HeadLocation);
        }

        //public int Controls(ConsoleKey key)
        //{
        //    if (key == ConsoleKey.W)
        //    {
        //        return 0;
        //    }
        //    else if (key == ConsoleKey.D)
        //    {
        //        return 1;
        //    }
        //    else if (key == ConsoleKey.S)
        //    {
        //        return 2;
        //    }
        //    else if (key == ConsoleKey.A)
        //    {
        //        return 3;
        //    }
        //    else
        //    {
        //        return 4;
        //    }
        //}

        public void Controls(int movement)
        {
            if (movement == 0)
            {
                SnakeBody[0] = new Point(HeadLocation.X--, HeadLocation.Y);
            }
            else if (movement == 1)
            {
                SnakeBody[0] = new Point(HeadLocation.X, HeadLocation.Y++);
            }
            else if (movement == 2)
            {
                SnakeBody[0] = new Point(HeadLocation.X++, HeadLocation.Y);
            }
            else if (movement == 3)
            {
                SnakeBody[0] = new Point(HeadLocation.X, HeadLocation.Y--);
            }
        }

        public Point GetHeadLocation()
        {
            return HeadLocation;
        }

        public List<Point> GetBody()
        {
            return SnakeBody;
        }

    }
}
