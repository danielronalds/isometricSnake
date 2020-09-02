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

        public RenderComponent renderApple;
        public RenderComponent renderShadow;

        Rectangle appleRec; // rectangle for the apple sprite

        public Rectangle appleShadowRec; // rectange to paint the shadow with, and for collision tracking

        Image appleImage;

        Image appleShadow;

        int animationCurrentCycle, animationMaxCycle = 8; // Keeps track of the animation frame

        public Apple(Point Spawn)
        {
            appleLocation = Spawn;

            appleSize = new Size(48, 48);

            appleRec = new Rectangle(appleLocation, appleSize);

            appleShadowRec = appleRec;

            appleImage = Properties.Resources.isometric_apple_no_shadow;

            appleShadow = Properties.Resources.isometric_apple_shadow;

            renderApple = new RenderComponent(appleImage, appleRec);

            renderShadow = new RenderComponent(appleShadow, appleShadowRec);
        }

        public void drawApple(Graphics g)
        {
            updateAnimation();

            g.DrawImage(appleShadow, appleShadowRec);
            g.DrawImage(appleImage, appleRec);
        }

        public void updateAnimation() // Creates the floating animation of the apple
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

            renderApple.RenderRect = appleRec;
        }
    }
}
