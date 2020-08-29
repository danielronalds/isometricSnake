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

        public void moveSnake(Point Location/*, string direction, int tailNumber, List<snakeSegment> tailList*/)
        {
            previousPoint = snakeRec.Location;

            //previousDirection = Direction;

            snakeRec.Location = Location;

            //Direction = direction;

            //switch (Direction)
            //{
            //    case "left":
            //        snakeImage = Properties.Resources.snake_2;
            //        if(tailNumber != 0)
            //        {
            //            if (tailList[tailNumber - 1].Direction != "left")
            //            {
            //                if(tailList[tailNumber - 1].Direction == "down")
            //                {
            //                    snakeImage = Properties.Resources.snake_3;
            //                } else
            //                {
            //                    snakeImage = Properties.Resources.snake_head;
            //                }
            //            }
            //        }
            //        break;
            //    case "down":
            //        snakeImage = Properties.Resources.snake_3;

            //        if (tailNumber != 0)
            //        {
            //            if (tailList[tailNumber - 1].Direction != "down")
            //            {
            //                if (tailList[tailNumber - 1].Direction == "left")
            //                {
            //                    snakeImage = Properties.Resources.snake_2;
            //                }
            //                else
            //                {
            //                    snakeImage = Properties.Resources.snake_head;
            //                }
            //            }
            //        }
            //        break;
            //    default:
            //        snakeImage = Properties.Resources.snake_head;
            //        break;
            //}
        }

        public void drawSnake(Graphics g)
        {
            g.DrawImage(snakeImage, snakeRec);

        }
    }
}
