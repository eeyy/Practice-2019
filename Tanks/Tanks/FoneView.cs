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
            return CreateMap(arrCoordinateHurdles);
        }


        public Image CreateMap(Point[] arrCoordinates)
        {
            Bitmap flag = new Bitmap(Resource1.fone);
            Graphics flagGraphics = Graphics.FromImage(flag);
            for (int i = 0; i < arrCoordinates.Length; i++)
            {

                flagGraphics.DrawImage(Resource1.stone, arrCoordinates[i].X, arrCoordinates[i].Y);
            }
            return flag;
        }
    }
}
