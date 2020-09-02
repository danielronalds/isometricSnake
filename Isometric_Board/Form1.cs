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

        SoundManager sound = new SoundManager();

        Renderer_v2 renderer = new Renderer_v2();

        List<RenderComponent> renderOrder = new List<RenderComponent>();

        bool snakeRight, snakeLeft, snakeUp, snakeDown;

        Random random = new Random();

        int gameState = 0;
        
        Snake snake;

        List<Apple> apples = new List<Apple>();

        int score;
        int highScore = 0;

        bool framePassed = false;

        Point[,] map;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });
            
            map = renderer.grid.Layers[1];

            apples.Add(new Apple(map[8, 5]));

            snake = new Snake(map[8,8]);
        }


        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            framePassed = false;

            if(gameState == 1)
            {
                snake.moveSnake(snakeUp, snakeDown, snakeLeft, snakeRight);
            } else if(gameState == 2)
            {
                if (score > highScore)
                {
                    highScore = score;

                    highestScoreLbl.Text = "" + highScore;
                }

                restartGame();
            }

            sortRenderOrder();

            checkCollisions();

            renderer.Render(g);

            apples[0].updateAnimation();

            foreach(RenderComponent renderComponent in renderOrder)
            {
                renderComponent.Render(g);
            }
        }

        private void refreshScreen_Tick(object sender, EventArgs e)
        {
            Canvas.Invalidate();
        }

        private void restartGame()
        {
            gameState = 0;

            apples.Clear();

            apples.Add(new Apple(map[8, 5]));

            snake = new Snake(map[8, 8]);

            score = 0;

            scoreLbl.Text = "" + score;

            framePassed = false;

            snakeLeft = false;
            snakeRight = false;
            snakeUp = false;
            snakeDown = false;
        }

        private void sortRenderOrder() // Figures out what order to draw the elements in
        {
            renderOrder.Clear();

            int[] appleLocation = getGridID(apples[0].appleShadowRec.Location);

            for (int i = 0; i < renderer.grid.gridSize; i++)
            {
                for (int x = 0; x < renderer.grid.gridSize; x++)
                {
                    if (map[i, x] == apples[0].appleShadowRec.Location) // Apple
                    {
                        renderOrder.Add(apples[0].renderShadow);
                        renderOrder.Add(apples[0].renderApple);
                    }

                    for (int tailNum = 0; tailNum < snake.tail.Count(); tailNum++) // Snake
                    {
                        snakeSegment tailUnit = snake.tail[tailNum];

                        if(map[i,x] == tailUnit.snakeRec.Location)
                        {
                            renderOrder.Add(tailUnit.renderer);
                        }
                    }
                }
            }
        }

        private int[] getGridID(Point Location)
        {
            for (int i = 0; i < renderer.grid.gridSize; i++)
            {
                for (int x = 0; x < renderer.grid.gridSize; x++)
                {
                    if(Location == map[i,x])
                    {
                        int[] mapLocation = { i, x };
                        return mapLocation;
                    }
                }
            }

            return null;
        }

        private Point randomLocation() // Generates a random location for the apple to spawn
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
            if(apples[0].appleShadowRec.Location == snake.tail[0].snakeRec.Location) // Checks if the snake has eaten an apple
            {
                score++;
                snake.TailLength++; // Updates score

                scoreLbl.Text = "" + score;

                sound.Pickup_Apple();

                foreach (snakeSegment tailUnit in snake.tail)
                {
                    while (apples[0].appleShadowRec.Location == tailUnit.snakeRec.Location) // Makes sure the apple doesnt spawn in the snake
                    {                                                                       // Using appleShadowRec as it doesnt get moved during the animation
                        apples.Clear();
                        apples.Add(new Apple(randomLocation()));
                    }
                }

                Console.WriteLine("Score: " + score);
            }

            if (outOfBounds() || snakeOverlapping()) // Checks to see if the snake went off the map or ran into itself
            {
                gameState = 2;
            }

        }

        private bool outOfBounds() // Checks to see if the snake is out of the map
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

        private bool snakeOverlapping() // Sees if the snake has eaten itself
        {
            for (int i = 0; i < snake.tail.Count() - 1; i++)
            {
                int x = i + 1;

                Point snakeHead = snake.tail[0].snakeRec.Location;

                Point snakeSegment = snake.tail[x].snakeRec.Location;

                if(snakeHead == snakeSegment)
                {
                    return true;
                }
            }
            return false;
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
    }
}
