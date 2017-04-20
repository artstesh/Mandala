using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandala
    {
    class SquareManager
        {
        public Point Center { get; set; }
        public int Length { get; set; }
        public List<Square> sectors { get; set; }

        public SquareManager(int xCenter, int yCenter, int length)
            {
                Length = length;
                Center = new Point(xCenter, yCenter);
                sectors = new List<Square>();
            }

            private List<Square> CreateSquares()
            {
            List<Square> result = new List<Square>();

            Point bl = Center;
            Point br = new Point(bl.X, bl.Y + Length);
            Point tl = new Point(bl.X-Length, bl.Y);
            Point tr = new Point(tl.X, tl.Y + Length);
            Square sq1 = new Square(tl,tr,bl,br);
            result.Add(sq1);

            tl = Center;
            tr = sq1.BottomRight;
            bl = new Point(tl.X + Length, tl.Y);
            br = new Point(tr.X + Length, tr.Y);
            Square sq2 = new Square(tl, tr, bl, br);
            result.Add(sq2);

            tr = sq2.TopLeft;
            br = sq2.BottomLeft;
            tl = new Point(tr.X, tr.Y - Length);
            bl = new Point(tl.X + Length, tl.Y);
            Square sq3 = new Square(tl, tr, bl, br);
            result.Add(sq3);

            tr = sq1.TopLeft;
            br = Center;
            bl = sq3.TopLeft;
            tl = new Point(tr.X, tr.Y - Length);
            Square sq4 = new Square(tl, tr, bl, br);
            result.Add(sq4);

            return result;
            }
        }
    }
