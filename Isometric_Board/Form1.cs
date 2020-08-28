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

        Apple apple;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });
            apple = new Apple(randomLocation());        
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            renderer.Render(g);

            apple.drawApple(g);
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
                    snakeRight = true;
                    break;

                case Keys.A:
                    snakeLeft = true;
                    break;

                case Keys.W:
                    snakeUp = true;
                    break;

                case Keys.S:
                    snakeDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    snakeRight = false;
                    break;

                case Keys.A:
                    snakeLeft = false;
                    break;

                case Keys.W:
                    snakeUp = false;
                    break;

                case Keys.S:
                    snakeDown = false;
                    break;
            }
        }
    }
}
