using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class TankView
    {
        private PictureBox MyPictureBox = new PictureBox();

        public PictureBox CreateViewTank(Point[] coordinates, PictureBox FormPictureBox)
        {

            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            for (int i = 0; i < coordinates.Length; i++)
            {
                flagGraphics.DrawImage(Resource1.tank, coordinates[i].X, coordinates[i].Y);
            }
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

        public PictureBox RemoveViewTank(Point coordinates, PictureBox FormPictureBox)
        {

            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            if (!coordinates.IsEmpty)
                flagGraphics.DrawImage(Resource1.fone, coordinates.X, coordinates.Y, 30, 34);//вопрос по размеру

            MyPictureBox.Image = flag;
            return MyPictureBox;
        }
    }
}
