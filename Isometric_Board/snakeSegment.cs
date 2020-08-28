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
            snakeImage = Properties.Resources.high_res_player_cube;
        }

        public void drawSnake(Graphics g, Point Location)
        {
            snakeRec.Location = Location;

            g.DrawImage(snakeImage, snakeRec);

            previousPoint = Location;
        }
    }
}
