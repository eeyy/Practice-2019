using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class TankController
    {
        int n = 0;
        private string[] arrDirection =
        {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"
        };
        Tank tank = new Tank();
        List<Tank> tanksList = new List<Tank>();
        BulletKolView bulletView = new BulletKolView();
        

        public List<Tank> CreateTank(Point[] arrCoordinateHurdles, Kolobok kolobok, Point[] arrCoordinateApple)//Первый танк почему-то ставится рандомно игнорируя стенки 
        {
            n++;////Первый танк почему-то ставится рандомно, игнорируя стенки 
            Point coordinatesTank = Point.Empty;
            int width = 56;
            int height = 56;
            int speed = 3; /////SPEED
            string direction = "RIGHT";

            Random random = new Random();

            bool check = true;

            if (n == 1)
            {
                coordinatesTank.X = 230;
                coordinatesTank.Y = 400;
            }
            else
                while (check)
                {
                    coordinatesTank.X = random.Next(36, 684);
                    coordinatesTank.Y = random.Next(16, 560);
                
                    if (checkCollisTank(coordinatesTank, arrCoordinateHurdles))
                        continue;
                    if (checkCollisTank(coordinatesTank, arrCoordinateApple))
                        continue;
                    if (checkCollisTank(coordinatesTank, transfCoordKolToArr(kolobok)))
                        continue;
                    if (checkCollisTank(coordinatesTank, tanksList))
                        continue;
                    check = false;
                }
            
            Tank tank = new Tank(coordinatesTank.X, coordinatesTank.Y, width, height, speed, direction);
            this.tank = tank;
            tanksList.Add(tank);

            return tanksList;
        }


        public void SetListTank(List<Tank> newTanksList)
        {
            tanksList = newTanksList;
        }


        public bool checkCollisTank(Point coordTank, Point[] arrCoordOtherObject)
        {
            int n = 0;
            for (int j = 0; j < arrCoordOtherObject.Length; j++)
            {
                if (!collides(coordTank.X, coordTank.Y, coordTank.X + tank.sizeX, coordTank.Y + tank.sizeY, arrCoordOtherObject[j].X, arrCoordOtherObject[j].Y, arrCoordOtherObject[j].X + 40, arrCoordOtherObject[j].Y + 40))
                    n++;
                else return true;
                if (n == arrCoordOtherObject.Length)
                    return false;
            }
            return false;
        }

        public bool checkCollisTank(Point coordTank, List<Tank> arrCoordOtherObject)
        {
            int n = 0;
            for (int j = 0; j < arrCoordOtherObject.Count; j++)
            {
                if (!collides(coordTank.X, coordTank.Y, coordTank.X + tank.sizeX, coordTank.Y + tank.sizeY, arrCoordOtherObject[j].x, arrCoordOtherObject[j].y, arrCoordOtherObject[j].x + tank.sizeX, arrCoordOtherObject[j].y + tank.sizeY))
                    n++;
                else return true;
                if (n == arrCoordOtherObject.Count)
                    return false;
            }
            return false;
        }


        public Point[] transfCoordKolToArr(Kolobok kolobok)
        {
            Point[] arrCoordKolobok = new Point[1];
            arrCoordKolobok[0].X = kolobok.x;
            arrCoordKolobok[0].Y = kolobok.y;
            return arrCoordKolobok;
        }

        

        public Tank EditDerection()
        {
            Random random = new Random();
            int numberDirec = random.Next(0, 4);
            int numderTank = random.Next(0, tanksList.Count);
            if (tanksList.Count != 0)
            {
                tanksList[numderTank].direction = arrDirection[numberDirec];
                return tanksList[numderTank];
            }
            return null;
        }

        public List<Tank> GoTank(Point[] arrCoordinateHurdles)
        {

            for (int i = 0; i < tanksList.Count; i++)
            {
                if (checkCollisionTankObstacle(tanksList[i], arrCoordinateHurdles))
                {

                    if (tanksList[i].direction == arrDirection[0])
                        tanksList[i].y -= tank.speed;
                    else if (tanksList[i].direction == arrDirection[1])
                        tanksList[i].y += tank.speed;
                    else if (tanksList[i].direction == arrDirection[2])
                        tanksList[i].x -= tank.speed;
                    else if (tanksList[i].direction == arrDirection[3])
                        tanksList[i].x += tank.speed;
                }
            }
            return tanksList;
        }

        public bool checkCollisionTankObstacle(Tank tank, Point[] arrCoordinateObstacle)
        {
            for (int i = 0; i < arrCoordinateObstacle.Length; i++)
            {
                if (tank.direction == "UP")
                {
                    if (collides(tank.x, tank.y, tank.x + tank.sizeX, tank.y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16 + tank.speed))
                        return false;
                }
                if (tank.direction == "DOWN")
                {
                    if (collides(tank.x, tank.y, tank.x + tank.sizeX, tank.y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y - tank.speed, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))
                        return false;
                }
                if (tank.direction == "LEFT")
                {
                    if (collides(tank.x - tank.speed, tank.y, tank.x + tank.sizeX, tank.y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))
                        return false;
                }
                if (tank.direction == "RIGHT")
                {
                    if (collides(tank.x, tank.y, tank.x + tank.sizeX + tank.speed, tank.y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))

                        return false;
                }
            }
            return true;
        }

        public void checkAccidentTankToTank()
        {
            for (int  i = 0; i < tanksList.Count; i++)
            {
                for (int j = 0; j < tanksList.Count; j++)
                {
                    if (tanksList[j].direction == "UP")
                    {
                        if (collides(tanksList[i].x, tanksList[i].y, tanksList[i].x + tank.sizeX, tanksList[i].y + tank.sizeY, tanksList[j].x, tanksList[j].y, tanksList[j].x + tank.sizeX, tanksList[j].y + tank.sizeY + tank.speed) && (tanksList[i] != tanksList[j]))
                            tanksList[j].direction = "DOWN";
                    }
                    else
                    {
                        if (tanksList[j].direction == "DOWN")
                        {
                            if (collides(tanksList[i].x, tanksList[i].y, tanksList[i].x + tank.sizeX, tanksList[i].y + tank.sizeY, tanksList[j].x, tanksList[j].y - tank.speed, tanksList[j].x + tank.sizeX, tanksList[j].y + tank.sizeY) && (tanksList[i] != tanksList[j]))
                                tanksList[j].direction = "UP";
                        }
                        else
                        {
                            if (tanksList[j].direction == "LEFT")
                            {
                                if (collides(tanksList[i].x - tank.speed, tanksList[i].y, tanksList[i].x + tank.sizeX, tanksList[i].y + tank.sizeY, tanksList[j].x, tanksList[j].y, tanksList[j].x + tank.sizeX, tanksList[j].y + tank.sizeY) && (tanksList[i] != tanksList[j]))
                                    tanksList[j].direction = "RIGHT";
                            }
                            else
                            {
                                if (tanksList[j].direction == "RIGHT")
                                {
                                    if (collides(tanksList[i].x, tanksList[i].y, tanksList[i].x + tank.sizeX + tank.speed, tanksList[i].y + tank.sizeY, tanksList[j].x, tanksList[j].y, tanksList[j].x + tank.sizeX, tanksList[j].y + tank.sizeY) && (tanksList[i] != tanksList[j]))
                                        tanksList[j].direction = "LEFT";
                                }
                            }
                        }
                    }
                }
            }
        }
        public bool checkAccidentTankToKolobok(Kolobok kolobok)
        {
            Point coordKolobok = new Point();
            coordKolobok.X = kolobok.x;
            coordKolobok.Y = kolobok.y;

            for (int j = 0; j < tanksList.Count; j++)
            {
                if (tanksList[j].direction == "UP")
                {
                    if (collides(coordKolobok.X, coordKolobok.Y, coordKolobok.X + tank.sizeX - 11, coordKolobok.Y + tank.sizeY - 15, tanksList[j].x, tanksList[j].y, tanksList[j].x + tank.sizeX - 11, tanksList[j].y + tank.sizeY + tank.speed))
                        return true;
                }
                else
                {
                    if (tanksList[j].direction == "DOWN")
                    {
                        if (collides(coordKolobok.X - 2, coordKolobok.Y, coordKolobok.X + tank.sizeX - 15, coordKolobok.Y + tank.sizeY - 15, tanksList[j].x, tanksList[j].y - tank.speed, tanksList[j].x + tank.sizeX - 11, tanksList[j].y + tank.sizeY))
                            return true;
                    }
                    else
                    {
                        if (tanksList[j].direction == "LEFT")
                        {
                            if (collides(coordKolobok.X - kolobok.speed, coordKolobok.Y, coordKolobok.X + tank.sizeX - 15, coordKolobok.Y + tank.sizeY - 15, tanksList[j].x, tanksList[j].y, tanksList[j].x + tank.sizeX - 3, tanksList[j].y + tank.sizeY))
                                return true;
                        }
                        else
                        {
                            if (tanksList[j].direction == "RIGHT")
                            {
                                if (collides(coordKolobok.X, coordKolobok.Y, coordKolobok.X + tank.sizeX + tank.speed - 15, coordKolobok.Y + tank.sizeY - 15, tanksList[j].x, tanksList[j].y, tanksList[j].x + tank.sizeX - 11, tanksList[j].y + tank.sizeY))
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
       

        public PictureBox BangTank(PictureBox pictureBox, Tank tank)
        {
            TankView tankView = new TankView();
            return tankView.RemoveViewTank(tank, pictureBox);
        }


        public bool collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x > r2 ||
                     b <= y2 || y > b2);
        }
    }
}
