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

        Image snakeImage;

        public snakeSegment(Point Location)
        {
            snakeRec = new Rectangle(Location, new Size(48,48));
            snakeImage = Properties.Resources.snake_head;
        }

        public void moveSnake(Point Location)
        {
            previousPoint = snakeRec.Location;

            snakeRec.Location = Location;
        }

        public void drawSnake(Graphics g)
        {
            g.DrawImage(snakeImage, snakeRec);
        }
    }
}
