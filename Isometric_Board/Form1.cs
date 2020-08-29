using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace isometricSnake
{
    public partial class Form1 : Form
    {
        Graphics g;

        Renderer_v2 renderer = new Renderer_v2();

        List<snakeSegment> renderOrder = new List<snakeSegment>();

        bool snakeRight, snakeLeft, snakeUp, snakeDown;

        Random random = new Random();

        int gameState = 0;
        
        Snake snake;

        Apple apple;

        int score;

        bool framePassed = false;

        Point[,] map;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });
            
            map = renderer.grid.Layers[1];

            apple = new Apple(map[5, 1]);

            snake = new Snake(map[5,5]);
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            framePassed = false;

            if(gameState == 1)
            {
                snake.moveSnake(snakeUp, snakeDown, snakeLeft, snakeRight);
            }

            sortRenderOrder();

            checkCollisions();

            renderer.Render(g);

            apple.drawApple(g);

            foreach (snakeSegment tailUnit in renderOrder)
            {
                tailUnit.drawSnake(g);
            }

            //snake.drawSnake(g);
        }

        private void refreshScreen_Tick(object sender, EventArgs e)
        {
            Canvas.Invalidate();
        }

        private void sortRenderOrder()
        {
            renderOrder.Clear();

            for (int i = 0; i < renderer.grid.gridSize; i++)
            {
                for (int x = 0; x < renderer.grid.gridSize; x++)
                {
                    foreach(snakeSegment tailUnit in snake.tail)
                    {
                        if(map[i,x] == tailUnit.snakeRec.Location)
                        {
                            renderOrder.Add(tailUnit);
                        }
                    }
                }
            }
        }

        private Point randomLocation()
        {
            Point[,] map = renderer.grid.Layers[1];

            Point location;

            int rndNumX;
            int rndNumY;

            rndNumX = random.Next(0, 10);
            rndNumY = random.Next(0, 10);

            location = map[rndNumX, rndNumY];

            return location;
        }

        private void checkCollisions()
        {
            if(apple.appleRec.Location == snake.tail[0].snakeRec.Location)
            {
                score++;
                snake.TailLength++;

                foreach (snakeSegment tail in snake.tail)
                {
                    while (apple.appleRec.Location == tail.snakeRec.Location)
                    {
                        apple.appleRec.Location = randomLocation();
                    }
                }

                Console.WriteLine("Score: " + score);
            }

            if (outOfBounds())
            {
                gameState = 2;
            }
        }

        private bool outOfBounds()
        {
            for (int i = 0; i < renderer.grid.gridSize; i++)
            {
                for (int x = 0; x < renderer.grid.gridSize; x++)
                {
                    if(map[i, x] == snake.tail[0].snakeRec.Location)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(!framePassed)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                    case Keys.Right:
                        if (!snakeLeft) // Prevents the snake from going through itself
                        {
                            snakeRight = true;
                            snakeLeft = false;
                            snakeUp = false;
                            snakeDown = false;
                        }
                        break;

                    case Keys.A:
                    case Keys.Left:
                        if (!snakeRight) // Prevents the snake from going through itself
                        {
                            snakeRight = false;
                            snakeLeft = true;
                            snakeUp = false;
                            snakeDown = false;
                        }
                        break;

                    case Keys.W:
                    case Keys.Up:
                        if (!snakeDown) // Prevents the snake from going through itself
                        {
                            snakeRight = false;
                            snakeLeft = false;
                            snakeUp = true;
                            snakeDown = false;
                        }
                        break;

                    case Keys.S:
                    case Keys.Down:
                        if (!snakeUp) // Prevents the snake from going through itself
                        {
                            snakeRight = false;
                            snakeLeft = false;
                            snakeUp = false;
                            snakeDown = true;
                        }
                        break;
                }

                framePassed = true;
            }

            if(gameState < 1)
            {
                gameState = 1;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}
