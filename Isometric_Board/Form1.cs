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

        bool snakeRight, snakeLeft, snakeUp, snakeDown;

        Random random = new Random();

        bool gameRunning = false;

        Snake snake;

        Apple apple;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });
            apple = new Apple(randomLocation());

            Point[,] map = renderer.grid.Layers[1];

            snake = new Snake(map[5,5]);
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            renderer.Render(g);

            apple.drawApple(g);

            if(gameRunning)
            {
                snake.moveSnake(snakeUp, snakeDown, snakeLeft, snakeRight);
            }

            snake.drawSnake(g);
        }

        private void refreshScreen_Tick(object sender, EventArgs e)
        {
            Canvas.Invalidate();
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                case Keys.Right:
                    snakeRight = true;
                    snakeLeft = false;
                    snakeUp = false;
                    snakeDown = false;
                    break;

                case Keys.A:
                case Keys.Left:
                    snakeRight = false;
                    snakeLeft = true;
                    snakeUp = false;
                    snakeDown = false;
                    break;

                case Keys.W:
                case Keys.Up:
                    snakeRight = false;
                    snakeLeft = false;
                    snakeUp = true;
                    snakeDown = false;
                    break;

                case Keys.S:
                case Keys.Down:
                    snakeRight = false;
                    snakeLeft = false;
                    snakeUp = false;
                    snakeDown = true;
                    break;
            }
            if(!gameRunning)
            {
                gameRunning = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}
