using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandala
    {
    class SectorManager
        {

            public SectorManager(int xCenter, int yCenter, int number)
            {
                Center = new Point(xCenter, yCenter);
                Number = number;
            sectors = new List<Sector>();
            }

            public Point Center { get; set; }
            public int Number { get; set; }
        public int Length { get; set; }
            public List<Sector> sectors { get; set; }

            public void MakeSectors()
            {
                double angle = 360.0 / Number;
                Point start = new Point(Center.X - Length, Center.Y);
                for (int i = 0; i < Number; i++)
                {
                    Sector temp = new Sector();
                    temp.X = Center;
                    temp.Y = start;
              //      temp.Z = FindZ(angle, Center, start);
                }
            }

      /*  private Point FindZ(double angle, Point center, Point start)
        {
            double sideLength = 2 * (Length ^ 2) - (Length ^2 )* Math.Cos(angle);
            sideLength = Math.Sqrt(sideLength);
        }*/
        }
    }
