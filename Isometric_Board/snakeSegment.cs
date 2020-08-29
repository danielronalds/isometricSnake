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

        public string previousDirection; 
        
        public string Direction;

        Image snakeImage;

        public snakeSegment(Point Location)
        {
            snakeRec = new Rectangle(Location, new Size(48,48));
            snakeImage = Properties.Resources.snake_head;
        }

        public void drawSnake(Graphics g, Point Location, string direction)
        {
            previousPoint = snakeRec.Location;

            previousDirection = Direction;

            snakeRec.Location = Location;

            Direction = direction;

            switch (Direction)
            {
                case "left":
                    snakeImage = Properties.Resources.snake_2;
                    break;
                case "down":
                    snakeImage = Properties.Resources.snake_3;
                    break;
                default:
                    snakeImage = Properties.Resources.snake_head;
                    break;
            }

            g.DrawImage(snakeImage, snakeRec);

        }
    }
}
