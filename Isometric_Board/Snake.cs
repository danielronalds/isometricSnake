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

        public Rectangle snakeRec;

        Point previousPoint;

        String direction;

        public int TailLength = 3;

        String previousDirection;

        Image snakeImage;

        public Snake(Point Location)
        {
            //snakeRec = new Rectangle(Location, new Size(48, 48));
            //snakeImage = Properties.Resources.snake_head;

            tail.Add(new snakeSegment(Location));

            Console.WriteLine("Tail Length: " + tail.Count());
        }

        public void drawSnake(Graphics g)
        {
            g.DrawImage(snakeImage, snakeRec);

            //foreach (snakeSegment segment in tail)
            //{
            //    segment.drawSnake(g);
            //}
        }

        public void moveSnake(bool snakeUp, bool snakeDown, bool snakeLeft, bool snakeRight)
        {
            tail[0].previousPoint = tail[0].snakeRec.Location;
            previousDirection = direction;

            if (snakeUp)
            {
                tail[0].snakeRec.X -= 22;
                tail[0].snakeRec.Y -= 11;

                //tail[0].direction = "up";
            }
            else if(snakeDown)
            {
                tail[0].snakeRec.X += 22;
                tail[0].snakeRec.Y += 11;

                //direction = "down";
            }
            else if(snakeLeft)
            {
                tail[0].snakeRec.X -= 22;
                tail[0].snakeRec.Y += 11;

                //direction = "left";
            }
            else if(snakeRight)
            {
                tail[0].snakeRec.X += 22;
                tail[0].snakeRec.Y -= 11;

                //direction = "right";
            }

            if(tail.Count() < TailLength)
            {
                tail.Add(new snakeSegment(tail[0].previousPoint));
                Console.WriteLine("Tail length: " + tail.Count());
            }

            //for (int i = 0; i < tail.Count(); i++)
            //{
            //    if (i == 0)
            //    {
            //        tail[i].moveSnake(previousPoint, previousDirection, i, tail);
            //    }
            //    else
            //    {
            //        tail[i].moveSnake(tail[i - 1].previousPoint, tail[i - 1].previousDirection, i, tail);
            //    }
            //}

            for (int i = 0; i < tail.Count()-1; i++)
            {
                int x = i + 1;

                tail[x].moveSnake(tail[i].previousPoint);
            }
        }
    }
}
