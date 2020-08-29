using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class Snake
    {
        public List<snakeSegment> tail = new List<snakeSegment>();

        public int TailLength = 3;

        public Snake(Point Location)
        {
            tail.Add(new snakeSegment(Location));

            Console.WriteLine("Tail Length: " + tail.Count());
        }

        public void moveSnake(bool snakeUp, bool snakeDown, bool snakeLeft, bool snakeRight)
        {
            tail[0].previousPoint = tail[0].snakeRec.Location;

            if (snakeUp)
            {
                tail[0].snakeRec.X -= 22;
                tail[0].snakeRec.Y -= 11;
            }
            else if(snakeDown)
            {
                tail[0].snakeRec.X += 22;
                tail[0].snakeRec.Y += 11;
            }
            else if(snakeLeft)
            {
                tail[0].snakeRec.X -= 22;
                tail[0].snakeRec.Y += 11;
            }
            else if(snakeRight)
            {
                tail[0].snakeRec.X += 22;
                tail[0].snakeRec.Y -= 11;
            }

            if(tail.Count() < TailLength)
            {
                tail.Add(new snakeSegment(tail[0].previousPoint));
                Console.WriteLine("Tail length: " + tail.Count());
            }

            for (int i = 0; i < tail.Count()-1; i++)
            {
                int x = i + 1;

                tail[x].moveSnake(tail[i].previousPoint);
            }
        }
    }
}
