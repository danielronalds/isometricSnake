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

        Rectangle appleRec;

        public Rectangle appleShadowRec;

        Image appleImage;

        Image appleShadow;

        int animationCurrentCycle, animationMaxCycle = 8;

        public Apple(Point Spawn)
        {
            appleLocation = Spawn;

            appleSize = new Size(48, 48);

            appleRec = new Rectangle(appleLocation, appleSize);

            appleShadowRec = appleRec;

            appleImage = Properties.Resources.isometric_apple_no_shadow;

            appleShadow = Properties.Resources.isometric_apple_shadow;
        }

        public void drawApple(Graphics g)
        {
            updateAnimation();

            g.DrawImage(appleShadow, appleShadowRec);
            g.DrawImage(appleImage, appleRec);
        }

        public void updateAnimation()
        {
            if(animationCurrentCycle < animationMaxCycle/2)
            {
                animationCurrentCycle++;
                appleRec.Y++;
            } else if(animationCurrentCycle < animationMaxCycle)
            { 
                animationCurrentCycle++;
                appleRec.Y--;
            } else
            {
                animationCurrentCycle = 0;
            }
        }
    }
}
