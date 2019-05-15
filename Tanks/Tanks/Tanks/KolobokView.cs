using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class KolobokView
    {
        private PictureBox MyPictureBox = new PictureBox();
        private Image imageKolobol = Resource1.packman;
        private string oldDirection = "RIGHT";

        public void EditImageKolobok(Keys keys)//поворачивает рисунок в зависимости от направления движения
        {
            if (oldDirection == "RIGHT")
            {
                switch (keys)
                {
                    case Keys.Down:
                        oldDirection = "DOWN";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case Keys.Up:
                        oldDirection = "UP";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                    case Keys.Left:
                        oldDirection = "LEFT";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate180FlipY);
                        break;
                }
            }
            else if (oldDirection == "LEFT")
            {
                switch (keys)
                {
                    case Keys.Down:
                        oldDirection = "DOWN";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                    case Keys.Up:
                        oldDirection = "UP";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case Keys.Right:
                        oldDirection = "RIGHT";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate180FlipY);
                        break;
                }
            }
            else if (oldDirection == "DOWN")
            {
                switch (keys)
                {
                    case Keys.Left:
                        oldDirection = "LEFT";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                    case Keys.Up:
                        oldDirection = "UP";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Keys.Right:
                        oldDirection = "RIGHT";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                }
            }
            else if (oldDirection == "UP")
            {
                switch (keys)
                {
                    case Keys.Left:
                        oldDirection = "LEFT";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case Keys.Down:
                        oldDirection = "DOWN";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Keys.Right:
                        oldDirection = "RIGHT";
                        imageKolobol.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                }
            }
        }

        public PictureBox CreateViewKolobok(Point coordinates, PictureBox FormPictureBox)
        {
            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.DrawImage(Resource1.fone, coordinates.X , coordinates.Y + 2, 42, 40);
            flagGraphics.DrawImage(imageKolobol, coordinates.X, coordinates.Y);

            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

        public PictureBox GameOver(Point coordinates, PictureBox FormPictureBox)
        {
            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            flagGraphics.DrawImage(Resource1.bang, coordinates.X, coordinates.Y, 40, 40);
            flagGraphics.DrawImage(Resource1.gameOver, 200, 180);
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

        public PictureBox ResetViewKolobok(Point coordinates, PictureBox FormPictureBox)
        {
            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            flagGraphics.DrawImage(Resource1.fone, coordinates.X, coordinates.Y, 40, 40);

            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

    }
}
