namespace YMH219_FlappyBird
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            pbBird = new PictureBox();
            pbGround = new PictureBox();
            pbPipeTop1 = new PictureBox();
            pbPipeBottom1 = new PictureBox();
            pbPipeTop2 = new PictureBox();
            pbPipeBottom2 = new PictureBox();
            lblScore = new Label();
            lblMessage = new Label();
            btnRestart = new Button();
            ((System.ComponentModel.ISupportInitialize)pbBird).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGround).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeTop1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeBottom1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeTop2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeBottom2).BeginInit();
            SuspendLayout();
            // 
            // pbBird
            // 
            pbBird.BackColor = Color.Gold;
            pbBird.Location = new Point(30, 33);
            pbBird.Name = "pbBird";
            pbBird.Size = new Size(125, 62);
            pbBird.TabIndex = 0;
            pbBird.TabStop = false;
            // 
            // pbGround
            // 
            pbGround.BackColor = Color.SaddleBrown;
            pbGround.Location = new Point(30, 126);
            pbGround.Name = "pbGround";
            pbGround.Size = new Size(125, 62);
            pbGround.TabIndex = 1;
            pbGround.TabStop = false;
            // 
            // pbPipeTop1
            // 
            pbPipeTop1.BackColor = Color.ForestGreen;
            pbPipeTop1.Location = new Point(30, 234);
            pbPipeTop1.Name = "pbPipeTop1";
            pbPipeTop1.Size = new Size(125, 62);
            pbPipeTop1.TabIndex = 2;
            pbPipeTop1.TabStop = false;
            // 
            // pbPipeBottom1
            // 
            pbPipeBottom1.BackColor = Color.ForestGreen;
            pbPipeBottom1.Location = new Point(30, 339);
            pbPipeBottom1.Name = "pbPipeBottom1";
            pbPipeBottom1.Size = new Size(125, 62);
            pbPipeBottom1.TabIndex = 3;
            pbPipeBottom1.TabStop = false;
            // 
            // pbPipeTop2
            // 
            pbPipeTop2.BackColor = Color.ForestGreen;
            pbPipeTop2.Location = new Point(217, 33);
            pbPipeTop2.Name = "pbPipeTop2";
            pbPipeTop2.Size = new Size(125, 62);
            pbPipeTop2.TabIndex = 4;
            pbPipeTop2.TabStop = false;
            // 
            // pbPipeBottom2
            // 
            pbPipeBottom2.BackColor = Color.ForestGreen;
            pbPipeBottom2.Location = new Point(217, 126);
            pbPipeBottom2.Name = "pbPipeBottom2";
            pbPipeBottom2.Size = new Size(125, 62);
            pbPipeBottom2.TabIndex = 5;
            pbPipeBottom2.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(452, 46);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(50, 20);
            lblScore.TabIndex = 6;
            lblScore.Text = "label1";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(452, 115);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(50, 20);
            lblMessage.TabIndex = 7;
            lblMessage.Text = "label2";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(600, 46);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(132, 29);
            btnRestart.TabIndex = 8;
            btnRestart.Text = "Yeniden Başlat";
            btnRestart.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(782, 503);
            Controls.Add(btnRestart);
            Controls.Add(lblMessage);
            Controls.Add(lblScore);
            Controls.Add(pbPipeBottom2);
            Controls.Add(pbPipeTop2);
            Controls.Add(pbPipeBottom1);
            Controls.Add(pbPipeTop1);
            Controls.Add(pbGround);
            Controls.Add(pbBird);
            Name = "Form1";
            Text = "Flappy Bird - YMH 219";
            ((System.ComponentModel.ISupportInitialize)pbBird).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGround).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeTop1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeBottom1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeTop2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPipeBottom2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private PictureBox pbBird;
        private PictureBox pbGround;
        private PictureBox pbPipeTop1;
        private PictureBox pbPipeBottom1;
        private PictureBox pbPipeTop2;
        private PictureBox pbPipeBottom2;
        private Label lblScore;
        private Label lblMessage;
        private Button btnRestart;
    }
}
