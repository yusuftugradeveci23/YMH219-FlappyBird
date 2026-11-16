using System;
using System.Drawing;
using System.Windows.Forms;

namespace YMH219_FlappyBird
{
    public partial class Form1 : Form
    {
        private Bird _bird;
        private PipePair _pipePair1;
        private PipePair _pipePair2;
        private GameEngine _engine;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Ekran titremesini önler
            this.KeyPreview = true;     // Klavye tuşlarını formun yakalamasını garanti eder

            InitializeGameObjects();
            SetupTimerAndEvents();
            ResetUI();
        }

        private void InitializeGameObjects()
        {
            _bird = new Bird();
            _engine = new GameEngine();
            _pipePair1 = new PipePair(450, this.ClientSize.Height);
            _pipePair2 = new PipePair(850, this.ClientSize.Height);
        }

        private void SetupTimerAndEvents()
        {
            timer1.Interval = 20; // Saniyede 50 kare (50 FPS)
            timer1.Tick += GameLoop_Tick;
            this.KeyDown += Form1_KeyDown;
            btnRestart.Click += BtnRestart_Click;
        }

        private void ResetUI()
        {
            _bird.Reset();
            _engine.ResetGame();

            int height = this.ClientSize.Height;
            int width = this.ClientSize.Width;

            // Zemin ve Kuş konumları
            pbGround.SetBounds(0, height - 60, width, 60);
            pbBird.SetBounds(100, height / 2 - 20, 35, 35);

            // Boruların başlangıç konumları
            _pipePair1.ResetPosition(450, height);
            _pipePair2.ResetPosition(850, height);
            UpdatePipeControls(_pipePair1, pbPipeTop1, pbPipeBottom1);
            UpdatePipeControls(_pipePair2, pbPipeTop2, pbPipeBottom2);

            // Bilgi etiketleri ve buton durumu
            lblScore.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Location = new Point(15, 15);
            UpdateScoreLabel();

            lblMessage.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblMessage.ForeColor = Color.DarkRed;
            lblMessage.BackColor = Color.FromArgb(220, Color.White);
            lblMessage.AutoSize = true;
            lblMessage.Text = "Başlamak için SPACE (Boşluk) tuşuna basın!";
            CenterControl(lblMessage, -30);
            lblMessage.Visible = true;

            btnRestart.Size = new Size(160, 45);
            btnRestart.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRestart.BackColor = Color.Orange;
            btnRestart.ForeColor = Color.White;
            btnRestart.FlatStyle = FlatStyle.Flat;
            CenterControl(btnRestart, 35);
            btnRestart.Visible = false;

            this.Focus();
        }

        private void CenterControl(Control ctrl, int yOffset)
        {
            ctrl.Location = new Point(
                (this.ClientSize.Width - ctrl.Width) / 2,
                (this.ClientSize.Height - ctrl.Height) / 2 + yOffset
            );
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (!_engine.IsStarted || _engine.IsGameOver) return;

            // 1. Kuşa yer çekimi uygula
            _bird.ApplyGravity();
            pbBird.Top += _bird.VerticalSpeed;

            // 2. Boruları sola hareket ettir ve ekrandan çıkanları sıfırla
            MoveAndRecyclePipe(_pipePair1, pbPipeTop1, pbPipeBottom1, _pipePair2.X);
            MoveAndRecyclePipe(_pipePair2, pbPipeTop2, pbPipeBottom2, _pipePair1.X);

            // 3. Skor kontrolü (Kuş boruyu geçtiyse)
            CheckPipeScore(_pipePair1);
            CheckPipeScore(_pipePair2);

            // 4. Çarpışma kontrolü
            bool hitPipe1 = _engine.CheckCollision(pbBird.Bounds, pbPipeTop1.Bounds, pbPipeBottom1.Bounds, pbGround.Bounds);
            bool hitPipe2 = _engine.CheckCollision(pbBird.Bounds, pbPipeTop2.Bounds, pbPipeBottom2.Bounds, pbGround.Bounds);

            if (hitPipe1 || hitPipe2)
            {
                TriggerGameOver();
            }
        }

        private void MoveAndRecyclePipe(PipePair pair, PictureBox topPb, PictureBox bottomPb, int otherPipeX)
        {
            pair.Move(_engine.PipeSpeed);

            if (pair.X + pair.Width < 0)
            {
                int newX = Math.Max(this.ClientSize.Width, otherPipeX + 400);
                pair.ResetPosition(newX, this.ClientSize.Height);
            }

            UpdatePipeControls(pair, topPb, bottomPb);
        }

        private void UpdatePipeControls(PipePair pair, PictureBox topPb, PictureBox bottomPb)
        {
            topPb.SetBounds(pair.X, 0, pair.Width, pair.GapY);
            int bottomY = pair.GapY + pair.GapHeight;
            int bottomHeight = this.ClientSize.Height - bottomY - pbGround.Height;
            bottomPb.SetBounds(pair.X, bottomY, pair.Width, Math.Max(0, bottomHeight));
        }

        private void CheckPipeScore(PipePair pair)
        {
            if (!pair.IsPassed && pair.X + pair.Width < pbBird.Left)
            {
                pair.IsPassed = true;
                _engine.IncreaseScore();
                UpdateScoreLabel();
            }
        }

        private void UpdateScoreLabel()
        {
            lblScore.Text = $"Skor: {_engine.Score}   |   En Yüksek: {_engine.HighScore}   |   Hız: {_engine.PipeSpeed}";
        }

        private void TriggerGameOver()
        {
            _engine.EndGame();
            timer1.Stop();

            lblMessage.Text = $"GAME OVER! Skorunuz: {_engine.Score}";
            CenterControl(lblMessage, -30);
            lblMessage.Visible = true;
            lblMessage.BringToFront();

            btnRestart.Visible = true;
            btnRestart.BringToFront();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true; // Windows uyarı sesini engeller

                if (_engine.IsGameOver) return;

                if (!_engine.IsStarted)
                {
                    _engine.StartGame();
                    lblMessage.Visible = false;
                    timer1.Start();
                }

                _bird.Jump();
            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            ResetUI();
        }
    }
}
