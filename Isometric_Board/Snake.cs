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

        Image snakeImage;

        public Snake(Point Location)
        {
            snakeRec = new Rectangle(Location, new Size(48, 48));
            snakeImage = Properties.Resources.high_res_player_cube;

            Point previousSpawn = Location;

            for (int i = 0; i < 5; i++)
            {
                Point spawn = new Point(previousSpawn.X + (22 * (i+ 1)), previousSpawn.Y + (11 * (i + 1)));

                tail.Add(new snakeSegment(spawn));

                //previousSpawn = spawn;
            }

            Console.WriteLine("Tail count: " + tail.Count());
        }

        public void drawSnake(Graphics g)
        {
            g.DrawImage(snakeImage, snakeRec);
            for (int i = 0; i < tail.Count(); i++)
            {
                if(i == 0)
                {
                    tail[i].drawSnake(g, previousPoint);
                }
                else
                {
                    tail[i].drawSnake(g, tail[i - 1].previousPoint);
                }
            }
        }

        public void moveSnake(bool snakeUp, bool snakeDown, bool snakeLeft, bool snakeRight)
        {
            previousPoint = snakeRec.Location;

            if (snakeUp)
            {
                snakeRec.X -= 22;
                snakeRec.Y -= 11;
            }
            else if(snakeDown)
            {
                snakeRec.X += 22;
                snakeRec.Y += 11;
            }
            else if(snakeLeft)
            {
                snakeRec.X -= 22;
                snakeRec.Y += 11;
            }
            else if(snakeRight)
            {
                snakeRec.X += 22;
                snakeRec.Y -= 11;
            }
        }

    }
}
