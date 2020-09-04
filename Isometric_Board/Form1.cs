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
using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace isometricSnake
{
    public partial class Form1 : Form
    {

        Graphics g;

        SoundManager sound = new SoundManager();

        TextManager fonts = new TextManager();

        Renderer_v2 renderer = new Renderer_v2();

        List<RenderComponent> renderOrder = new List<RenderComponent>();

        bool snakeRight, snakeLeft, snakeUp, snakeDown;

        Random random = new Random();

        int gameState = 0;

        Snake snake;

        List<Apple> apples = new List<Apple>();

        int score = 0;
        int highScore = 0;

        bool framePassed = false;

        bool nameBox = false;
        string playerName;

        Point[,] map;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });

            fonts.InitializeFonts();

            map = renderer.grid.Layers[1];

            apples.Add(new Apple(map[8, 5]));

            snake = new Snake(map[8,8]);

            helpButton.Font = fonts.labelFont;

            if(!nameBox)
            {
                namePanel.Visible = false;
                namePanel.Enabled = false;
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            framePassed = false;

            if(gameState == 1)
            {
                // Hides help button and border button
                helpButton.Visible = false;
                borderButton.Visible = false;

                snake.moveSnake(snakeUp, snakeDown, snakeLeft, snakeRight);
            } else if(gameState == 2)
            {
                if (score > highScore)
                {
                    highScore = score;
                }

                restartGame();
            } else
            {
                // Shows help button and border button
                helpButton.Visible = true;
                borderButton.Visible = true;
            }

            sortRenderOrder();

            checkCollisions();

            renderer.Render(g);

            apples[0].updateAnimation();

            foreach(RenderComponent renderComponent in renderOrder)
            {
                renderComponent.Render(g);
            }

            fonts.drawScoreText(g, score, Canvas.Size);
            fonts.drawHighScoreText(g, highScore, Canvas.Size);
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

                sound.Pickup_Apple();

                while (insideSnake(apples[0].appleShadowRec)) // Makes sure the apple doesnt spawn in the snake
                {                                                                       // Using appleShadowRec as it doesnt get moved during the animation
                    apples.Clear();
                    apples.Add(new Apple(randomLocation()));
                }

                Console.WriteLine("Score: " + score);
            }

            if (outOfBounds() || snakeOverlapping()) // Checks to see if the snake went off the map or ran into itself
            {
                gameState = 2;
            }

        }

        private bool insideSnake(Rectangle appleRec)
        {
            foreach(snakeSegment tailUnit in snake.tail)
            {
                if(appleRec.Location == tailUnit.snakeRec.Location)
                {
                    return true;
                }
            }

            return false;
        }

        private void helpButton_Click(object sender, EventArgs e) // Game instructions
        {
            string Title = "Game Instructions";

            string Message = "The objective of the game is to get as many points as you can by eating apples that are randomly generated on the map. For each apple you eat, your tail grows by one.\n\n" +
                "The game ends if you either go off the map, or hit your own tail" +
                "\n\nControls:" +
                "\nW/Up Arrow: Changes the direction of the snake so that it is moving towards the top of the screen" +
                "\nS/Down Arrow: Changes the direction of the snake so that it is moving towards the bottom of the screen" +
                "\nD/Left Arrow: Changes the direction of the snake so that it is moving towards the left of the screen" +
                "\nA/Right Arrow: Changes the direction of the snake so that it is moving towards the right of the screen" +
                "\n\nNOTE: If the snake is moving up, it can not go down, and vice versa. This also applies to left and right movement. This is so the player cannot die by accident";

            if(playerName != null)
            {
                Message = "Hi " + playerName + "!\n\n" + Message;
            }

            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void nameField_KeyDown(object sender, KeyEventArgs e) // For the criteria
        {
            string name = nameField.Text;

            if(e.KeyCode == Keys.Enter)
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))//checks name for letters
                {
                    MessageBox.Show("Please enter a name using letters only!");
                    nameField.Clear();

                    nameField.Focus();
                }
                else
                {
                    playerName = name; // saves player Name

                    namePanel.Visible = false;
                    namePanel.Enabled = false;

                }
            }
        }

        private void borderButton_Click(object sender, EventArgs e) // Allows the player to turn borders on and off
        {
            bool borderedButton = false;

            foreach(IsometricTile tile in renderer.tiles)
            {
                if(!tile.Bordered)
                {
                    tile.tileImage = Properties.Resources.high_res_isometric_cube_white_bordered;

                    tile.Bordered = true;
                    borderedButton = true;

                } else
                {
                    tile.tileImage = Properties.Resources.high_res_isometric_cube_white;

                    tile.Bordered = false;
                }
            }

            if(borderedButton)
            {
                borderButton.Image = Properties.Resources.borders_button;
            } else
            {
                borderButton.Image = Properties.Resources.borders_button_off;
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
