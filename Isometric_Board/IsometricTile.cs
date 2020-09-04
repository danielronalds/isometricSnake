using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class IsometricTile
    {
        int width, height, x, y;

        public Image tileImage;
        public Rectangle tileRec;

        public string tileID;

        public bool Bordered = false;

        public IsometricTile(Point Position, string ID)
        {
            x = Position.X;
            y = Position.Y;
            width = 48;
            height = width;

            tileID = ID;

            tileImage = Properties.Resources.high_res_isometric_cube_white;

            tileRec = new Rectangle(x, y, width, height);
        }

        public void drawTile(Graphics g)
        {
            g.DrawImage(tileImage, tileRec);
        }
    }
}
