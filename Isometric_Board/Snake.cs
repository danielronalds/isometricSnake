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

        public int TailLength = 0;

        String previousDirection;

        Image snakeImage;

        public Snake(Point Location)
        {
            snakeRec = new Rectangle(Location, new Size(48, 48));
            snakeImage = Properties.Resources.snake_head;

            Console.WriteLine("Tail count: " + tail.Count());
        }

        public void drawSnake(Graphics g)
        {
            g.DrawImage(snakeImage, snakeRec);

            for (int i = 0; i < tail.Count(); i++)
            {
                if(i == 0)
                {
                    tail[i].drawSnake(g, previousPoint, previousDirection);
                } else
                {
                    tail[i].drawSnake(g, tail[i - 1].previousPoint, tail[i - 1].previousDirection);
                }
            }
        }

        public void moveSnake(bool snakeUp, bool snakeDown, bool snakeLeft, bool snakeRight)
        {
            previousPoint = snakeRec.Location;
            previousDirection = direction;

            if (snakeUp)
            {
                snakeRec.X -= 22;
                snakeRec.Y -= 11;

                direction = "up";
            }
            else if(snakeDown)
            {
                snakeRec.X += 22;
                snakeRec.Y += 11;

                direction = "down";
            }
            else if(snakeLeft)
            {
                snakeRec.X -= 22;
                snakeRec.Y += 11;

                direction = "left";
            }
            else if(snakeRight)
            {
                snakeRec.X += 22;
                snakeRec.Y -= 11;

                direction = "right";
            }

            if(tail.Count() < TailLength)
            {
                tail.Add(new snakeSegment(previousPoint));
            }
        }
    }
}
