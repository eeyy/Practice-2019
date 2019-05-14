using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class AppleView
    {
        private PictureBox MyPictureBox = new PictureBox();

        public PictureBox CreateViewApple(Point[] coordinates, PictureBox FormPictureBox)
        {
            
            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            for (int i = 0; i < coordinates.Length; i++)
            {
                flagGraphics.DrawImage(Resource1.apple, coordinates[i].X, coordinates[i].Y);
            }
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

        public PictureBox RemoveViewApple(Point coordinates, PictureBox FormPictureBox)
        {
           
            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            if (!coordinates.IsEmpty)
                flagGraphics.DrawImage(Resource1.fone, coordinates.X, coordinates.Y, 30, 34);
            
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

    }
}
