using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace Snake {
    internal class Snake {
        public List<Block> rects = new List<Block>();
        public Direction dir { get; set; } = Direction.DOWN;
        private bool isAddBlock = false;
        //private Form1 game = Program.form;

        public Snake() {
            rects.Add(new Block(60, 60));
        }

        public void OnUpdate() {
            Block currentLast = rects[rects.Count - 1];
            this.SetNext();
            if (isAddBlock) {
                this.rects.Add(currentLast);
                isAddBlock = false;
            }
        }

        private Block GetLeadBlock() {
            int bx = rects[0].X;
            int by = rects[0].Y;
            switch (dir) {
                case Direction.UP:
                    by -= 20;
                    break;
                case Direction.DOWN:
                    by += 20; 
                    break;
                case Direction.LEFT:
                    bx -= 20;
                    break;
                case Direction.RIGHT:
                    bx += 20;
                    break;
            }
            return new Block(bx, by);
        }

        private void SetNext() {
            var newRects = new List<Block>();
            newRects.Add(this.GetLeadBlock());
            for (int i = 0; i < rects.Count - 1; i++) {
                newRects.Add(rects[i]);
            }
            this.rects = newRects.ToList();
        }

        public void AddBlock() {
            //Block reb;
            //Block cb = this.rects[rects.Count - 1];
            /*
            switch (dir) {
                case Direction.UP:
                    reb = new Block(cb.X, cb.Y + 20);
                    break;
                case Direction.DOWN:
                    reb = new Block(cb.X, cb.Y - 20);
                    break;
                case Direction.LEFT:
                    reb = new Block(cb.X + 20, cb.Y);
                    break;
                case Direction.RIGHT:
                    reb = new Block(cb.X - 20, cb.Y);
                    break;
                default:
                    reb = cb;
                    break;           
            }
            */
            //rects.Add(cb);
            this.isAddBlock = true;
        }

        public void Draw(Graphics g) {
            if (g == null)
                return;
            foreach (Block b in rects) {
                b.Draw(g);
            }
        }

        public bool IsGameOver() {
            //if (game == null)
            //    return false;

            var width = Program.form.GetWidth();
            var heigth = Program.form.GetHeigth();
            var leadBlock = this.rects[0];
            var currentX = leadBlock.X;
            var currentY = leadBlock.Y;

            if (currentX > width || currentX < 0) {
                return true;
            } else if (currentY > heigth || currentY < 0) {
                return true;
            }

            foreach (Block b in rects) {
                if (b.Equals(leadBlock))
                    continue;
                if (b.X == currentX && b.Y == currentY)
                    return true;
            }
            return false;
        }

        public bool IsTouch(Block apple) {
            var appleX = apple.X;
            var appleY = apple.Y;
            var leadBlock = this.rects[0];
            var currentX = leadBlock.X;
            var currentY = leadBlock.Y;

            return appleX == currentX && appleY == currentY;
        }
    }
}
