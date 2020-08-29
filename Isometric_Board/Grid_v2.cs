using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class Grid_v2
    {
        int x_offset = 396;
        int y_offset = 130;

        public int gridSize = 17;
        public int gridSizeZ = 2;

        public List<Point[,]> Layers = new List<Point[,]>();

        //public Point[,] Layer;

        public Grid_v2()
        {
            for (int i = 0; i < gridSizeZ; i++)
            {
                Layers.Add(loadLayer(i));
            }
        }

        public Point[,] loadLayer(int layerNumber)
        {
            Point[,] Layer = new Point[gridSize, gridSize];

            int layer_y;

            layer_y = y_offset - (23 * layerNumber);

            for (int i = 0; i < gridSize; i++)
            {
                Layer[i, 0] = new Point(x_offset + (22 * (i+1)), layer_y + (11 * (i + 1)));
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Point previousTile;//= new Point(0,0);

                    if (i == 0)
                    {
                        previousTile = Layer[x, i];
                    }
                    else
                    {
                        previousTile = Layer[x, i - 1];
                    }

                    Layer[x,i] = new Point(previousTile.X - 22, previousTile.Y + 11);
                }
            }

            return Layer;
        }
    }
}
