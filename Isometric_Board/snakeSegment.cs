using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class snakeSegment
    {
        public Point previousPoint;

        public Rectangle snakeRec;

        public string previousDirection;

        Image snakeImage;

        public snakeSegment(Point Location)
        {
            snakeRec = new Rectangle(Location, new Size(48,48));
            snakeImage = Properties.Resources.snake_head;
        }

        public void drawSnake(Graphics g, Point Location, string direction)
        {
            snakeRec.Location = Location;

            previousPoint = Location;

            previousDirection = direction;

            switch (direction)
            {
                case "left":
                    snakeRec.X -= 22;
                    snakeRec.Y += 11;
                    snakeImage = Properties.Resources.snake_2;
                    break;
                case "down":
                    snakeRec.X += 22;
                    snakeRec.Y += 11;
                    snakeImage = Properties.Resources.snake_3;
                    break;
                default:
                    snakeImage = Properties.Resources.snake_head;
                    break;
            }

            g.DrawImage(snakeImage, snakeRec);

        }
    }
}
