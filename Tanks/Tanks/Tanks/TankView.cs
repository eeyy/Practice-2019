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
        private Image imageTankRight = Resource1.tankRight;
        private Image imageTankLeft = Resource1.tankLeft;
        private Image imageTankUp = Resource1.tankUp;
        private Image imageTankDown = Resource1.tankDown;


        public PictureBox CreateViewTank(List<Tank> tanksList, PictureBox FormPictureBox)
        {
            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);
            for (int i = 0; i < tanksList.Count; i++)
            {
                if (tanksList[i].direction == "RIGHT")
                {
                    flagGraphics.DrawImage(imageTankRight, tanksList[i].x, tanksList[i].y);
                }
                else if (tanksList[i].direction == "LEFT")
                {
                    flagGraphics.DrawImage(imageTankLeft, tanksList[i].x, tanksList[i].y);
                }
                else if (tanksList[i].direction == "UP")
                {
                    flagGraphics.DrawImage(imageTankUp, tanksList[i].x, tanksList[i].y);
                }
                else if (tanksList[i].direction == "DOWN")
                {
                    flagGraphics.DrawImage(imageTankDown, tanksList[i].x, tanksList[i].y);
                }
            }
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }


        public PictureBox RemoveViewTank(Tank tank, PictureBox FormPictureBox)
        {

            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.DrawImage(Resource1.fone, tank.x, tank.y, tank.sizeX, tank.sizeY);
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

        public PictureBox BangViewTank(Tank tank, PictureBox FormPictureBox)
        {

            Bitmap flag = new Bitmap(FormPictureBox.Image);
            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.DrawImage(Resource1.bang, tank.x, tank.y, tank.sizeX, tank.sizeY);
            MyPictureBox.Image = flag;
            return MyPictureBox;
        }

        /*
        public PictureBox EditImageTank(Tank tank)//поворачивает рисунок в зависимости от направления движения
        {
            //oldDirection = tank.oldDirection;

            if (tank.oldDirection == "RIGHT")
            {
                switch (tank.direction)
                {
                    case "DOWN":
                        tank.oldDirection = "DOWN";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case "UP":
                        tank.oldDirection = "UP";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                    case "LEFT":
                        tank.oldDirection = "LEFT";
                        imageTank.RotateFlip(RotateFlipType.Rotate180FlipY);
                        break;
                }
            }
            else if (tank.oldDirection == "LEFT")
            {
                switch (tank.direction)
                {
                    case "DOWN":
                        tank.oldDirection = "DOWN";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                    case "UP":
                        tank.oldDirection = "UP";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case "RIGHT":
                        tank.oldDirection = "RIGHT";
                        imageTank.RotateFlip(RotateFlipType.Rotate180FlipY);
                        break;
                }
            }
            else if (tank.oldDirection == "DOWN")
            {
                switch (tank.direction)
                {
                    case "LEFT":
                        tank.oldDirection = "LEFT";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                    case "UP":
                        tank.oldDirection = "UP";
                        imageTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case "RIGHT":
                        tank.oldDirection = "RIGHT";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                }
            }
            else if (tank.oldDirection == "UP")
            {
                switch (tank.direction)
                {
                    case "LEFT":
                        tank.oldDirection = "LEFT";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case "DOWN":
                        tank.oldDirection = "DOWN";
                        imageTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case "RIGHT":
                        tank.oldDirection = "RIGHT";
                        imageTank.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;
                }
            }
            Point[] coordinatesTank = new Point[1];
            coordinatesTank[0].X = tank.x;
            coordinatesTank[0].Y = tank.y;
            CreateViewTank(coordinatesTank, pictureBox);
            return CreateViewTank(coordinatesTank, pictureBox);
        }

    */
    }
}
