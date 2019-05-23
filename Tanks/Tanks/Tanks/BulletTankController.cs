using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class BulletTankController
    {
        PackmanController packmanController = new PackmanController();
        BulletTankView bulletTankView = new BulletTankView();
        List<Bullet> bulletTankList = new List<Bullet>();

        private string[] arrDirection =
        {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"
        };

        public List<Bullet> CreateTankBullet(List<Tank> tanksList)
        {
            Point coordinatesBullet = Point.Empty;
            int width = 19;
            int height = 15;
            int speed = 8; /////SPEED

            Random random = new Random();
            int numberDirec = random.Next(0, 4);
            int numderTank = random.Next(0, tanksList.Count);
            if (tanksList.Count != 0)
            {
                tanksList[numderTank].direction = arrDirection[numberDirec];

                if (tanksList[numderTank].direction == arrDirection[0])
                {
                    coordinatesBullet.X = tanksList[numderTank].x + tanksList[numderTank].sizeX / 2 - 5;
                    coordinatesBullet.Y = tanksList[numderTank].y;
                }
                else if (tanksList[numderTank].direction == arrDirection[1])
                {
                    coordinatesBullet.X = tanksList[numderTank].x + tanksList[numderTank].sizeX / 2 - 4;
                    coordinatesBullet.Y = tanksList[numderTank].y + tanksList[numderTank].sizeY / 2;
                }
                else if (tanksList[numderTank].direction == arrDirection[2])
                {
                    coordinatesBullet.X = tanksList[numderTank].x;
                    coordinatesBullet.Y = tanksList[numderTank].y + tanksList[numderTank].sizeY / 2 - 5;
                }
                else if (tanksList[numderTank].direction == arrDirection[3])
                {
                    coordinatesBullet.X = tanksList[numderTank].x + tanksList[numderTank].sizeX / 2;
                    coordinatesBullet.Y = tanksList[numderTank].y + tanksList[numderTank].sizeY / 2 - 5;
                }

                string direction = tanksList[numderTank].direction;

                Bullet bullet = new Bullet(coordinatesBullet.X, coordinatesBullet.Y, width, height, speed, direction);

                bulletTankList.Add(bullet);

                return bulletTankList;
            }
            return null;
        }


        public PictureBox GoTankBullet(Point[] arrCoordinateObstacle, PictureBox pictureBox, Point[] arrCoordinateMonolith)
        {
            for (int i = 0; i < bulletTankList.Count; i++)
            {
                Point sizeHurdles = new Point { X = 36, Y = 16 };
                Point sizeMonolith = new Point { X = 36, Y = 32 };

                if (checkCollisionBulletObstacle(bulletTankList[i], arrCoordinateObstacle, sizeHurdles) & checkCollisionBulletObstacle(bulletTankList[i], arrCoordinateMonolith, sizeMonolith))
                {
                    if (bulletTankList[i].direction == arrDirection[0])
                        bulletTankList[i].y -= bulletTankList[i].speed;
                    else if (bulletTankList[i].direction == arrDirection[1])
                        bulletTankList[i].y += bulletTankList[i].speed;
                    else if (bulletTankList[i].direction == arrDirection[2])
                        bulletTankList[i].x -= bulletTankList[i].speed;
                    else if (bulletTankList[i].direction == arrDirection[3])
                        bulletTankList[i].x += bulletTankList[i].speed;
                }
                else
                {
                    pictureBox = bulletTankView.RemoveViewBullet(bulletTankList[i], pictureBox);
                    bulletTankList.RemoveAt(i);
                }
            }
            return pictureBox;
        }


        public List<Bullet> GetListTankBullet()
        {
            return bulletTankList;
        }


        //Взаимодействие с препятствием
        public bool checkCollisionBulletObstacle(Bullet bullet, Point[] arrCoordinateObstacle, Point sizeObstacle)
        {
            for (int i = 0; i < arrCoordinateObstacle.Length; i++)
            {
                if (bullet.direction == "UP")
                {
                    if (collides(bullet.x, bullet.y, bullet.x + bullet.sizeX, bullet.y + bullet.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + sizeObstacle.X, arrCoordinateObstacle[i].Y + sizeObstacle.Y + bullet.speed))
                        return false;
                }
                if (bullet.direction == "DOWN")
                {
                    if (collides(bullet.x, bullet.y, bullet.x + bullet.sizeX, bullet.y + bullet.sizeY + 4, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y - bullet.speed, arrCoordinateObstacle[i].X + sizeObstacle.X, arrCoordinateObstacle[i].Y + sizeObstacle.Y))
                        return false;
                }
                if (bullet.direction == "LEFT")
                {
                    if (collides(bullet.x - bullet.speed, bullet.y, bullet.x + bullet.sizeX, bullet.y + bullet.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + sizeObstacle.X, arrCoordinateObstacle[i].Y + sizeObstacle.Y))
                        return false;
                }
                if (bullet.direction == "RIGHT")
                {
                    if (collides(bullet.x, bullet.y, bullet.x + bullet.sizeX + bullet.speed + 5, bullet.y + bullet.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + sizeObstacle.X, arrCoordinateObstacle[i].Y + sizeObstacle.Y))

                        return false;
                }
            }
            return true;
        }

        public bool checkAccidentBullToKolobok(Kolobok kolobok)
        {
            Point coordKolobok = new Point();
            coordKolobok.X = kolobok.x;
            coordKolobok.Y = kolobok.y;

            for (int j = 0; j < bulletTankList.Count; j++)
            {
                if (bulletTankList[j].direction == "UP")
                {
                    if (collides(coordKolobok.X, coordKolobok.Y, coordKolobok.X + kolobok.sizeX , coordKolobok.Y + kolobok.sizeY , bulletTankList[j].x, bulletTankList[j].y, bulletTankList[j].x + bulletTankList[j].sizeX , bulletTankList[j].y + bulletTankList[j].sizeY + bulletTankList[j].speed))
                        return true;
                }
                else
                {
                    if (bulletTankList[j].direction == "DOWN")
                    {
                        if (collides(coordKolobok.X, coordKolobok.Y, coordKolobok.X + kolobok.sizeX , coordKolobok.Y + kolobok.sizeY , bulletTankList[j].x, bulletTankList[j].y - bulletTankList[j].speed, bulletTankList[j].x + bulletTankList[j].sizeX, bulletTankList[j].y + bulletTankList[j].sizeY))
                            return true;
                    }
                    else
                    {
                        if (bulletTankList[j].direction == "LEFT")
                        {
                            if (collides(coordKolobok.X - bulletTankList[j].speed, coordKolobok.Y, coordKolobok.X + kolobok.sizeX , coordKolobok.Y + kolobok.sizeY , bulletTankList[j].x, bulletTankList[j].y, bulletTankList[j].x + bulletTankList[j].sizeX , bulletTankList[j].y + bulletTankList[j].sizeY))
                                return true;
                        }
                        else
                        {
                            if (bulletTankList[j].direction == "RIGHT")
                            {
                                if (collides(coordKolobok.X, coordKolobok.Y, coordKolobok.X + kolobok.sizeX + bulletTankList[j].speed , coordKolobok.Y + kolobok.sizeY , bulletTankList[j].x, bulletTankList[j].y, bulletTankList[j].x + bulletTankList[j].sizeX , bulletTankList[j].y + bulletTankList[j].sizeY))
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        


        public bool collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x > r2 ||
                     b <= y2 || y > b2);
        }
    }
}