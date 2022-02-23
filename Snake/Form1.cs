using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake {
    public partial class Form1 : Form {
        private Snake snake;
        private Apple apple;

        private int score;
        public Form1() {
            InitializeComponent();
            this.snake = new Snake();
            this.SummonApple();
            this.score = 0;
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            snake.Draw(g);
            apple.Draw(g);
        }

        private void Tick_Tick(object sender, EventArgs e) {
            snake.OnUpdate();
            //snake.AddBlock();
            GameScreen.Refresh();

            if (snake.IsGameOver()) {
                Tick.Stop();
                MessageBox.Show($"GameOver!\nScore: {score}");
            }

            if (snake.IsTouch(apple)) {
                score += 10;
                if (Tick.Interval > 20) {
                    Tick.Interval -= 5;
                }
                snake.AddBlock();
                SummonApple();
                this.Text = $"すねーく！！ Score: {score}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            var key = e.KeyCode.ToString();
            switch (key) {
                case "W":
                    snake.dir = Direction.UP;
                    break;
                case "S":
                    snake.dir = Direction.DOWN;
                    break;
                case "A":
                    snake.dir = Direction.LEFT;
                    break;
                case "D":
                    snake.dir = Direction.RIGHT;
                    break;
                case "F":
                    snake.AddBlock();
                    break;
            }
        }

        private void SummonApple() {
            var r = new Random();
            var x = r.Next(1, GetWidth() + 1);
            var y = r.Next(1, GetHeigth() + 1);
            x -= x % 20;
            y -= y % 20;
            this.apple = new Apple(x, y);
        }

        public int GetWidth() {
            return GameScreen.Width;
        }

        public int GetHeigth() {
            return GameScreen.Height;
        }
    }
}
