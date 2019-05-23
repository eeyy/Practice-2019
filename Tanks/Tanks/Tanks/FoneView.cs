using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class FoneView
    {
        public Image CreateViewFone(Point[] arrCoordinateHurdles, Point[] arrCoordinateRiver, Point[] arrCoordinateMonolith)
        {
            Bitmap flag = new Bitmap(Resource1.fone);
            Graphics flagGraphics = Graphics.FromImage(flag);

            
            CreateViewObjectMap(flag, arrCoordinateHurdles, Resource1.stone);
            CreateViewObjectMap(flag, arrCoordinateMonolith, Resource1.monolith);
            CreateViewObjectMap(flag, arrCoordinateRiver, Resource1.river);//почему рисует??!
            return flag;
        }

        public Image CreateViewObjectMap(Bitmap gameImage, Point[] arrCoordinateObject, Image resourceImage)
        {
            Bitmap flag = gameImage;
            Graphics flagGraphics = Graphics.FromImage(flag);
            

            for (int i = 0; i < arrCoordinateObject.Length; i++)
            {
                flagGraphics.DrawImage(resourceImage, arrCoordinateObject[i].X, arrCoordinateObject[i].Y);
            }
            return flag;
        }
    }
}
