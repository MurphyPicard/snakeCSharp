﻿using System;
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


    public class Settings // I deleted internal for a test
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public bool GameOver { get; set; }
        public Direction direction { get; set; }

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
