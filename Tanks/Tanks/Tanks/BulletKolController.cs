using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class BulletKolController
    {
        TankController tankController = new TankController();
        BulletKolView bulletKolobokView = new BulletKolView();
        List<Bullet> bulletKolobokList = new List<Bullet>();
        //добавить стрельбу танкам
        private string[] arrDirection =
        {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"
        };

        public List<Bullet> CreateKolobokBullet(Kolobok kolobok)
        {
            Point coordinatesBullet = Point.Empty;
            int width = 19;
            int height = 15;
            int speed = 8; /////SPEED


            if (kolobok.direction == arrDirection[0])
            {
                coordinatesBullet.X = kolobok.x + kolobok.sizeX / 2 - 3;
                coordinatesBullet.Y = kolobok.y;
            }
            else if (kolobok.direction == arrDirection[1])
            {
                coordinatesBullet.X = kolobok.x + kolobok.sizeX / 2 - 4;
                coordinatesBullet.Y = kolobok.y + kolobok.sizeY / 2;
            }
            else if (kolobok.direction == arrDirection[2])
            {
                coordinatesBullet.X = kolobok.x;
                coordinatesBullet.Y = kolobok.y + kolobok.sizeY / 2 - 5;
            }
            else if (kolobok.direction == arrDirection[3])
            {
                coordinatesBullet.X = kolobok.x + kolobok.sizeX / 2;
                coordinatesBullet.Y = kolobok.y + kolobok.sizeY / 2 - 5;
            }


            string direction = kolobok.direction;

            Bullet bullet = new Bullet(coordinatesBullet.X, coordinatesBullet.Y, width, height, speed, direction);

            bulletKolobokList.Add(bullet);

            return bulletKolobokList;
        }

        

        public PictureBox GoKolobokBullet(Point[] arrCoordinateObstacle, PictureBox pictureBox)
        {
            for (int i = 0; i < bulletKolobokList.Count; i++)
            {
                if (checkCollisionBulletObstacle(bulletKolobokList[i], arrCoordinateObstacle))
                {
                    if (bulletKolobokList[i].direction == arrDirection[0])
                        bulletKolobokList[i].y -= bulletKolobokList[i].speed;
                    else if (bulletKolobokList[i].direction == arrDirection[1])
                        bulletKolobokList[i].y += bulletKolobokList[i].speed;
                    else if (bulletKolobokList[i].direction == arrDirection[2])
                        bulletKolobokList[i].x -= bulletKolobokList[i].speed;
                    else if (bulletKolobokList[i].direction == arrDirection[3])
                        bulletKolobokList[i].x += bulletKolobokList[i].speed;
                }
                else
                {
                    pictureBox = bulletKolobokView.RemoveViewBullet(bulletKolobokList[i], pictureBox);
                    bulletKolobokList.RemoveAt(i);
                }
            }
            return pictureBox;
        }

        public List<Bullet> GetListKolobokBullet()
        {
            return bulletKolobokList;
        }

        

        //Взаимодействие с препятствием
        public bool checkCollisionBulletObstacle(Bullet bullet, Point[] arrCoordinateObstacle)
        {
            for (int i = 0; i < arrCoordinateObstacle.Length; i++)
            {
                if (bullet.direction == "UP")
                {
                    if (collides(bullet.x, bullet.y, bullet.x + bullet.sizeX, bullet.y + bullet.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16 + bullet.speed))
                        return false;
                }
                if (bullet.direction == "DOWN")
                {
                    if (collides(bullet.x, bullet.y, bullet.x + bullet.sizeX, bullet.y + bullet.sizeY + 5, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y - bullet.speed, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))
                        return false;
                }
                if (bullet.direction == "LEFT")
                {
                    if (collides(bullet.x - bullet.speed, bullet.y, bullet.x + bullet.sizeX, bullet.y + bullet.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))
                        return false;
                }
                if (bullet.direction == "RIGHT")
                {
                    if (collides(bullet.x, bullet.y, bullet.x + bullet.sizeX + bullet.speed + 2, bullet.y + bullet.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))

                        return false;
                }
            }
            return true;
        }


        public PictureBox checkAccidentTankToBullet(List<Tank> tanksList, PictureBox pictureBox)
        {
            for (int i = 0; i < tanksList.Count; i++)
            {
                for (int j = 0; j < bulletKolobokList.Count; j++)
                {
                    if (bulletKolobokList[j].direction == "UP")
                    {
                        if (collides(tanksList[i].x, tanksList[i].y, tanksList[i].x + tanksList[i].sizeX, tanksList[i].y + tanksList[i].sizeY, bulletKolobokList[j].x, bulletKolobokList[j].y, bulletKolobokList[j].x + bulletKolobokList[j].sizeX, bulletKolobokList[j].y + bulletKolobokList[j].sizeY + bulletKolobokList[j].speed))
                        {
                            pictureBox = bulletKolobokView.RemoveViewBullet(bulletKolobokList[j], pictureBox);
                            bulletKolobokList.RemoveAt(j);
                            pictureBox = tankController.BangTank(pictureBox, tanksList[i]);
                            tanksList.RemoveAt(i);
                            tankController.SetListTank(tanksList);
                        }
                    }
                    else
                    {
                        if (bulletKolobokList[j].direction == "DOWN")
                        {
                            if (collides(tanksList[i].x, tanksList[i].y, tanksList[i].x + tanksList[i].sizeX, tanksList[i].y + tanksList[i].sizeY, bulletKolobokList[j].x, bulletKolobokList[j].y - bulletKolobokList[j].speed, bulletKolobokList[j].x + bulletKolobokList[j].sizeX, bulletKolobokList[j].y + bulletKolobokList[j].sizeY))
                            {
                                pictureBox = bulletKolobokView.RemoveViewBullet(bulletKolobokList[j], pictureBox);
                                bulletKolobokList.RemoveAt(j);
                                pictureBox = tankController.BangTank(pictureBox, tanksList[i]);
                                tanksList.RemoveAt(i);
                                tankController.SetListTank(tanksList);

                            }
                        }
                        else
                        {
                            if (bulletKolobokList[j].direction == "LEFT")
                            {
                                if (collides(tanksList[i].x - tanksList[i].speed, tanksList[i].y, tanksList[i].x + tanksList[i].sizeX, tanksList[i].y + tanksList[i].sizeY, bulletKolobokList[j].x, bulletKolobokList[j].y, bulletKolobokList[j].x + bulletKolobokList[j].sizeX, bulletKolobokList[j].y + bulletKolobokList[j].sizeY))
                                {
                                    pictureBox = bulletKolobokView.RemoveViewBullet(bulletKolobokList[j], pictureBox);
                                    bulletKolobokList.RemoveAt(j);
                                    pictureBox = tankController.BangTank(pictureBox, tanksList[i]);
                                    tanksList.RemoveAt(i);
                                    tankController.SetListTank(tanksList);
                                }
                            }
                            else
                            {
                                if (bulletKolobokList[j].direction == "RIGHT")
                                {
                                    if (collides(tanksList[i].x, tanksList[i].y, tanksList[i].x + tanksList[i].sizeX + tanksList[i].speed, tanksList[i].y + tanksList[i].sizeY, bulletKolobokList[j].x, bulletKolobokList[j].y, bulletKolobokList[j].x + bulletKolobokList[j].sizeX, bulletKolobokList[j].y + bulletKolobokList[j].sizeY))
                                    {
                                        pictureBox = bulletKolobokView.RemoveViewBullet(bulletKolobokList[j], pictureBox);
                                        bulletKolobokList.RemoveAt(j);
                                        pictureBox = tankController.BangTank(pictureBox, tanksList[i]);
                                        tanksList.RemoveAt(i);
                                        tankController.SetListTank(tanksList);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return pictureBox;
        }


        public bool collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x > r2 ||
                     b <= y2 || y > b2);
        }
    }
}
