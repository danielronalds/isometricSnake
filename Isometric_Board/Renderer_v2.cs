using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class Renderer_v2
    {
        public Grid_v2 grid = new Grid_v2();

        public GridMap_v2 gridMap = new GridMap_v2();

        public List<IsometricTile> tiles = new List<IsometricTile>();

        public Renderer_v2()
        {
            loadIsometricTiles();
        }

        public void Render(Graphics g)
        {
            foreach (IsometricTile tile in tiles)
            {
                tile.drawTile(g);
            }
        }

        private void loadIsometricTiles()
        {
            string ID;
            int layerNumber = -1;

            foreach (Point[,] layer in grid.Layers)
            {
                layerNumber++;
                for (int i = 0; i < grid.gridSize; i++)
                {
                    for (int x = 0; x < grid.gridSize; x++)
                    {
                        string[,] map = gridMap.Layers[layerNumber];
                        if(map[x, i] != "0")
                        {
                            ID = layerNumber + "-" + "-" + i + "-" + x;
                            tiles.Add(new IsometricTile(layer[x, i], ID, false));
                        }
                    }
                }
            }

            foreach (IsometricTile tile in tiles)
            {
                Console.WriteLine(tile.tileID);
            }

            Console.WriteLine("Total tiles: " + tiles.Count());
        }
    }
}
