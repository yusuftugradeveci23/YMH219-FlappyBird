using System.Drawing;
using System.IO;

namespace YMH219_FlappyBird
{
    public class GameEngine
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }
        public int PipeSpeed { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool IsStarted { get; private set; }

        private readonly string _highScoreFile = "highscore.txt";

        public GameEngine()
        {
            LoadHighScore();
            ResetGame();
        }

        public void StartGame()
        {
            IsStarted = true;
        }

        public void ResetGame()
        {
            Score = 0;
            PipeSpeed = 6;
            IsGameOver = false;
            IsStarted = false;
        }

        public void IncreaseScore()
        {
            Score++;
            if (Score % 5 == 0)
            {
                PipeSpeed++;
            }

            if (Score > HighScore)
            {
                HighScore = Score;
                SaveHighScore();
            }
        }

        public void EndGame()
        {
            IsGameOver = true;
            IsStarted = false;
        }

        public bool CheckCollision(Rectangle birdBounds, Rectangle topPipe, Rectangle bottomPipe, Rectangle ground)
        {
            return birdBounds.IntersectsWith(topPipe) ||
                   birdBounds.IntersectsWith(bottomPipe) ||
                   birdBounds.IntersectsWith(ground) ||
                   birdBounds.Top < 0;
        }

        private void LoadHighScore()
        {
            try
            {
                if (File.Exists(_highScoreFile))
                {
                    string content = File.ReadAllText(_highScoreFile);
                    if (int.TryParse(content, out int savedScore))
                    {
                        HighScore = savedScore;
                    }
                }
            }
            catch
            {
                HighScore = 0;
            }
        }

        private void SaveHighScore()
        {
            try
            {
                File.WriteAllText(_highScoreFile, HighScore.ToString());
            }
            catch
            {
                // Dosya yazma izni yoksa oyunun çökmesini önler
            }
        }
    }
}