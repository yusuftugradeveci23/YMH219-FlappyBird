using System;

namespace YMH219_FlappyBird
{
    public class PipePair
    {
        public int X { get; set; }
        public int GapY { get; private set; }
        public int GapHeight { get; set; } = 150;
        public int Width { get; set; } = 70;
        public bool IsPassed { get; set; }

        private static readonly Random _random = new Random();

        public PipePair(int startX, int formHeight)
        {
            X = startX;
            RandomizeHeight(formHeight);
        }

        public void Move(int speed)
        {
            X -= speed;
        }

        public void ResetPosition(int newX, int formHeight)
        {
            X = newX;
            IsPassed = false;
            RandomizeHeight(formHeight);
        }

        private void RandomizeHeight(int formHeight)
        {
            GapY = _random.Next(70, formHeight - GapHeight - 100);
        }
    }
}