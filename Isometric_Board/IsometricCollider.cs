using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class IsometricCollider
    {
        Rectangle displayRec = new Rectangle(0, 0, 48, 48);

        public Rectangle[] colliders = new Rectangle[11];

        public IsometricCollider(Point location)
        {
            displayRec.Location = location;
            configureCollisionArray();
        }

        public void drawVisual(Graphics g)
        {
            g.DrawImage(Properties.Resources.high_res_bottom_collider, displayRec);
            for (int i = 0; i < 11; i++)
            {
                g.DrawRectangle(Pens.White, createCollider(i + 1));
            }
        }

        public void updatePosition(Point new_location)
        {
            displayRec.Location = new_location;
            configureCollisionArray();
        }

        private void configureCollisionArray()
        {
            for (int i = 0; i < 11; i++)
            {
                colliders[i] = createCollider(i + 1);
            }
        }

        public Rectangle createCollider(int number)
        {
            Rectangle colliderRec;

            int x, y, width, height;

            x = displayRec.X + (23 - (number * 2));
            y = displayRec.Y + (23 + number);

            width = 1 + (number * 4);
            height = 24 - (number * 2);

            colliderRec = new Rectangle(x, y, width, height);

            return colliderRec;
        }
    }
}
