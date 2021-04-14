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
            Size = 5;
            SnakeBody = new List<Point>();
            int startpos = 20;
            for (int i = 0; i < 5; i++)
            {
                SnakeBody.Insert(i, new Point(startpos + i, startpos));
            }
            HeadLocation = SnakeBody.First();
        }

        public Point Controls(int movement)
        {
            Point changeTo = new Point(HeadLocation.X, HeadLocation.Y);
            Point oldPos = new Point(1, 1);
            if (movement == 0)
            {
                SnakeBody[0] = new Point(HeadLocation.X--, HeadLocation.Y);
                for (int i = 1; i < SnakeBody.Count; i++)
                {
                    oldPos = SnakeBody[i];
                    SnakeBody[i] = changeTo;
                    changeTo = oldPos;
                }
            }
            else if (movement == 1)
            {
                SnakeBody[0] = new Point(HeadLocation.X, HeadLocation.Y++);
                for (int i = 1; i < SnakeBody.Count; i++)
                {
                    oldPos = SnakeBody[i];
                    SnakeBody[i] = changeTo;
                    changeTo = oldPos;
                }
            }
            else if (movement == 2)
            {
                SnakeBody[0] = new Point(HeadLocation.X++, HeadLocation.Y);
                for (int i = 1; i < SnakeBody.Count; i++)
                {
                    oldPos = SnakeBody[i];
                    SnakeBody[i] = changeTo;
                    changeTo = oldPos;
                }
            }
            else if (movement == 3)
            {
                SnakeBody[0] = new Point(HeadLocation.X, HeadLocation.Y--);
                for (int i = 1; i < SnakeBody.Count; i++)
                {
                    oldPos = SnakeBody[i];
                    SnakeBody[i] = changeTo;
                    changeTo = oldPos;
                }
            }
            return oldPos;
        }

        public void AddBody()
        {
            SnakeBody.Insert(0, HeadLocation);
            Size++;
        }

        public Point GetHeadLocation()
        {
            return HeadLocation;
        }

        public List<Point> GetBody()
        {
            return SnakeBody;
        }

        public int GetSize()
        {
            return Size;
        }

    }
}
