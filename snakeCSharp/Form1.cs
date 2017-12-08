using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snakeCSharp
{
    public partial class Form1 : Form
    {
        private List<Circle>Snake = new List<Circle>();
        private Circle food = new Circle();

        // making _settings available to all functions
        Settings _settings = new Settings();

        public Form1()
        {
            

            InitializeComponent();

            // Set settings to default
            var settings = new Settings();

            // Set game speed and start timer
            gameTimer.Interval = 10000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
           
            // Start new game
            StartGame();
           
        }

        private void StartGame()
        {
            

            lblGameOver.Visible = false;

            // Set settings to default
            var settings = new Settings();

            // Create new player object
            Snake.Clear();
            Circle head = new Circle
            {
                X = 10,
                Y = 5
            };
            Snake.Add(head);

            lblScore.Text = Settings.Score.ToString();
            GenerateFood();

        }

        // Place a random food pellet
        private void GenerateFood()
        {
            
            var maxXPos = pbCanvas.Size.Width / Settings.Width;
            var maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Circle
            {
                X = random.Next(0, maxXPos),
                Y = random.Next(0, maxYPos)
            };


        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            // Check for Game Over
            if (_settings.GameOver == true)
            {
                // Check if Enter is pressed
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                Console.WriteLine("else");
                // Breakpoints added above and below this line.
                if (Input.KeyPressed(Keys.Right) && _settings.direction != Direction.Left)
                    _settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && _settings.direction != Direction.Right)
                    _settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Down) && _settings.direction != Direction.Up)
                    _settings.direction = Direction.Down;
                else if (Input.KeyPressed(Keys.Up) && _settings.direction != Direction.Down)
                    _settings.direction = Direction.Up;

                MovePlayer();
            }

            pbCanvas.Invalidate();

        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (_settings.GameOver == false)
            {
                // Set color of snake
                Brush snakeColor;

                //Draw snake
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                        snakeColor = Brushes.Black; // Draw head
                    else
                        snakeColor = Brushes.Green; // Draw body
                    
                    // Draw snake
                    canvas.FillEllipse(snakeColor, new Rectangle(Snake[i].X * Settings.Width,
                                                                 Snake[i].Y * Settings.Height,
                                                                 Settings.Width, 
                                                                 Settings.Height));

                    // Draw food
                    canvas.FillEllipse(Brushes.Red, new Rectangle(food.X * Settings.Width,
                                                                  food.Y * Settings.Height,
                                                                  Settings.Width, 
                                                                  Settings.Height));
                }
            }
            else
            {
                string gameOver = "Game over \nYour final score is: " + Settings.Score + "\nPress Enter to play again";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                // Move Head
                if (i == 0)
                {
                    switch (_settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        

                    }
                }
                else
                {
                    // Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }
    }
}
