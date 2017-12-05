using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakeCSharp
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }


    class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public int Score { get; set; }
        public int Points { get; set; }
        public bool GameOver { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 16;
            Score = 0;
            Points = 9;
            GameOver = false;
            direction = Direction.Down;

        }
    }
}
