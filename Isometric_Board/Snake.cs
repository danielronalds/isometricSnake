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

        int TailLength = 5;

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
                }
                else
                {
                    Point Location = tail[i - 1].previousPoint;
                    string Direction = tail[i - 1].previousDirection;

                    tail[i].drawSnake(g, Location, Direction);
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


            if (tail.Count() < TailLength)
            {
                Point spawnLocation = previousPoint;

                if(snakeLeft)
                {
                    spawnLocation.X -= 22;
                    spawnLocation.Y += 11;
                } else if (snakeRight)
                {
                    spawnLocation.X += 22;
                    spawnLocation.Y -= 11;
                } else if (snakeUp)
                {
                    spawnLocation.X -= 22;
                    spawnLocation.Y -= 11;
                } else if(snakeDown)
                {
                    spawnLocation.X += 22;
                    spawnLocation.Y += 11;
                }

                tail.Add(new snakeSegment(spawnLocation));
            }
        }

    }
}
