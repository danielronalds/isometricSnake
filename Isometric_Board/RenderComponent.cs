using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class RenderComponent
    {
        public Rectangle RenderRect;

        public Image RenderImage;

        public RenderComponent(Image image, Rectangle rectangle)
        {
            RenderImage = image;

            RenderRect = rectangle;
        }

        public void Render(Graphics g)
        {
            g.DrawImage(RenderImage, RenderRect);
        }

    }
}
