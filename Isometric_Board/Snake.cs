using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace isometricSnake
{
    class Snake
    {
        public List<snakeSegment> tail = new List<snakeSegment>();

        public int TailLength = 3;

        public Snake(Point Location)
        {
            tail.Add(new snakeSegment(Location));

            Console.WriteLine("Tail Length: " + tail.Count());
        }

        public void moveSnake(bool snakeUp, bool snakeDown, bool snakeLeft, bool snakeRight)
        {
            // tail[0] is the head of the snake

            tail[0].previousPoint = tail[0].snakeRec.Location; // Saves the previous location of the snakehead for the tail segment behind it to move to

            if(snakeUp)//if (snakeLeft) // Moves the snake head in the direction currently "selected"
            {
                tail[0].snakeRec.X -= 22;
                tail[0].snakeRec.Y -= 11;
            }
            if(snakeDown)//if(snakeRight)
            {
                tail[0].snakeRec.X += 22;
                tail[0].snakeRec.Y += 11;
            }
            if(snakeLeft)//if(snakeDown)
            {
                tail[0].snakeRec.X -= 22;
                tail[0].snakeRec.Y += 11;
            }
            if(snakeRight)//if(snakeUp) alternate control
            {
                tail[0].snakeRec.X += 22;
                tail[0].snakeRec.Y -= 11;
            }

            tail[0].renderer.RenderRect = tail[0].snakeRec;

            if(tail.Count() < TailLength) // Checks to see if the tail is as long as it should be, and if not adds a snake segement
            {
                tail.Add(new snakeSegment(tail[0].previousPoint));
                Console.WriteLine("Tail length: " + tail.Count());
            }

            for (int i = 0; i < tail.Count()-1; i++) // Moves the rest of the snake
            {
                int x = i + 1;

                tail[x].moveSnake(tail[i].previousPoint);
            }
        }
    }
}
