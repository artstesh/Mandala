using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Mandala
{
    public partial class Form1 : Form
    {
        private readonly List<TriangularPictureBox> triangles = new List<TriangularPictureBox>();
        private Color color = Color.Red;
        public Form1()
        {
            InitializeComponent();
            for (var i = 0; i < 4; i++)
                triangles.Add(new TriangularPictureBox(i));

            foreach (var triangle in triangles)
            {
                triangle.MouseMove += DrawPoint;
                Controls.Add(triangle);
            }
        }

        private void DrawPoint(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == 0) return;

            foreach (var triangle in triangles)
            {
                triangle.DrawPoint((sender as TriangularPictureBox).State, e.Location.X, e.Location.Y, color);
            }
            
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            var pictureBoxes = this.Controls.OfType<TriangularPictureBox>();
            foreach (var box in pictureBoxes)
            {
                box.Refresh();
            }
        }
        }
}