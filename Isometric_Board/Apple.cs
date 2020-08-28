using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class Apple
    {
        Size appleSize;
        Point appleLocation;

        public Rectangle appleRec;

        Image appleImage;

        public Apple(Point Spawn)
        {
            appleLocation = Spawn;

            appleSize = new Size(48, 48);

            appleRec = new Rectangle(appleLocation, appleSize);

            appleImage = Properties.Resources.isometric_apple;
        }

        public void drawApple(Graphics g)
        {
            g.DrawImage(appleImage, appleRec);
        }
    }
}
