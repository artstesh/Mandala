using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mandala
{
    internal sealed class TriangularPictureBox : PictureBox
    {
        private readonly Point _x;
        private readonly Point _y;
        private readonly Point _z;
        public readonly int State;
        

        public TriangularPictureBox(int state)
        {
            Width = state == 0 || state == 2 ? 500 : 250;
            Height = state == 0 || state == 2 ? 250 : 500;
            State = state;
            BackColor = Color.White;

            int zX = state !=3  ? Width : 0;
            int zY = state < 2 ? 0 : Height;
            int yX = state == 3 ? Width : 0;
            int yY = state == 0 ? 0 : (state == 2 ? Height : Height / 2);

            int xX = state == 3 ? 0 : (state == 1 ? Width : Width / 2);
            int xY = state < 2 ? Height : 0;
            int lX = state == 1 ? 250 : 0;
            int lY = state == 2 ? 250 : 0;

            Location = new Point(lX, lY);
            _x = new Point(xX, xY);
            _y = new Point(yX, yY);
            _z = new Point(zX, zY);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (var p = new GraphicsPath())
            {
                p.AddPolygon(new[] {_x, _y, _z});
                Region = new Region(p);
                base.OnPaint(pe);
            }
        }

        public void DrawPoint(int senderState, int x, int y, Color color)
        {
            var g = CreateGraphics();
            if (Math.Abs(State - senderState) % 2 == 0)
                g.DrawEllipse(new Pen(color, 1), GetX(x, senderState), GetY(y, senderState), 3, 3);
            else
                g.DrawEllipse(new Pen(color, 1), GetX(y, senderState), GetY(x, senderState), 3, 3);
            
        }

        private int GetX(int x, int sendState)
        {
            if (State == 0 && sendState > 1) return Width - x;
            if (State == 1 && sendState % 3 == 0) return Width - x;
            if (State == 2 && sendState < 2) return Width - x;
            if (State == 3 && (sendState == 1 || sendState == 2)) return Width - x;
            return x;
        }

        private int GetY(int y, int sendState)
        {
            if (State == 0 && (sendState == 1 || sendState == 2)) return Height - y;
            if (State == 1 && sendState > 1) return Height - y;
            if (State == 2 && sendState % 3 == 0) return Height - y;
            if (State == 3 && sendState < 2) return Height - y;
            return y;
        }
    }
}