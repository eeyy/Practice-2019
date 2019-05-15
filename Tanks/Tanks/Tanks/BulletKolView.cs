using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class BulletKolView
    {
        private PictureBox MyPictureBox = new PictureBox();
        private Image imageBulletRight = Resource1.bulletKolobokRight;
        private Image imageBulletLeft = Resource1.bulletKolobokLeft;
        private Image imageBulletUp = Resource1.bulletKolobokUp;
        private Image imageBulletDown = Resource1.bulletKolobokDown;


        public PictureBox CreateViewBullet(List<Bullet> bulletList, PictureBox FormPictureBox)
        {
            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (bulletList[i].direction == "RIGHT")
                {
                    flagGraphics.DrawImage(imageBulletRight, bulletList[i].x, bulletList[i].y);
                }
                else if (bulletList[i].direction == "LEFT")
                {
                    flagGraphics.DrawImage(imageBulletLeft, bulletList[i].x, bulletList[i].y);
                }
                else if (bulletList[i].direction == "UP")
                {
                    flagGraphics.DrawImage(imageBulletUp, bulletList[i].x, bulletList[i].y);
                }
                else if (bulletList[i].direction == "DOWN")
                {
                    flagGraphics.DrawImage(imageBulletDown, bulletList[i].x, bulletList[i].y);
                }
            }
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }


        public PictureBox RemoveViewBullet(Bullet bullet, PictureBox FormPictureBox)
        {

            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.DrawImage(Resource1.fone, bullet.x, bullet.y, 20, 20);

            MyPictureBox.Image = flag;
            return MyPictureBox;
        }
    }
}
