using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Snake {
    internal class Block : IDisposable {
        Rectangle block;
        public int X { get; set; }
        public int Y { get; set; }
        public Block(int x, int y) {
            this.X = x;
            this.Y = y;
            block = new Rectangle(this.X, this.Y, 20, 20);
        }

        public void Draw(Graphics g) {
            g.FillRectangle(Brushes.White, block);
        }

        public void Dispose() {
            //IDisposableを継承したはいいけど書くのめんどい
        }
    }
}
