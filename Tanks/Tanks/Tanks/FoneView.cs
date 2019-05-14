using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class FoneView
    {
        public Image CreateViewFone(Point[] arrCoordinateHurdles)
        {
            Bitmap flag = new Bitmap(Resource1.fone);
            Graphics flagGraphics = Graphics.FromImage(flag);
            for (int i = 0; i < arrCoordinateHurdles.Length; i++)
            {

                flagGraphics.DrawImage(Resource1.stone, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y);
            }
            return flag;
        }

    }
}
