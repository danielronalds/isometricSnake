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

        Image tileImage;

        public IsometricCollider collider;

        public Rectangle tileRec;

        public bool playerLayer;

        public string tileID;

        public IsometricTile(Point Position, string ID, bool PlayerLayer)
        {
            x = Position.X;
            y = Position.Y;
            width = 48;
            height = width;

            tileID = ID;

            tileImage = Properties.Resources.high_res_isometric_cube_white;

            tileRec = new Rectangle(x, y, width, height);

            if(PlayerLayer)
            {
                collider = new IsometricCollider(tileRec.Location);
            }

            playerLayer = PlayerLayer;
        }

        public void drawTile(Graphics g)
        {
            g.DrawImage(tileImage, tileRec);
            //g.DrawRectangle(Pens.Green, tileRec);
        }
    }
}
