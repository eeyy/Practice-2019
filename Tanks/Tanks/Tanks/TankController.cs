using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class TankController
    {
        private string direction = "RIGHT";
        private string[] arrDirection =
        {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"
        };
        Tank tank = new Tank();
        Point coordinatesTank = Point.Empty;


        public Point CreateTank(Point[] arrCoordinateHurdles, Kolobok kolobok, Point[] arrCoordinateApple, Point[] arrCoordinatesTank)//Первый танк почему-то ставится рандомно игнорируя стенки 
        {
            int width = 65;
            int height = 65;
            int speed = 3; /////SPEED
            Random random = new Random();
            
            
            bool check = true;

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
                if (checkCollisTank(coordinatesTank, arrCoordinatesTank))
                    continue;
                check = false;
            }

            Tank tank = new Tank(coordinatesTank.X, coordinatesTank.Y, width, height, speed);
            this.tank = tank;

            return coordinatesTank;
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
    
        public Point[] transfCoordKolToArr(Kolobok kolobok)
        {
            Point[] arrCoordKolobok = new Point[1];
            arrCoordKolobok[0].X = kolobok.x;
            arrCoordKolobok[0].Y = kolobok.y;
            return arrCoordKolobok;
        }

        public bool collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x > r2 ||
                     b <= y2 || y > b2);
        }






        public Point[] GoTank(Point[] arrPointsTank, Point[] arrCoordinateHurdles)
        {
            for (int i = 0; i < arrPointsTank.Length; i++)
            {
                if (checkCollisionTankObstacle(arrPointsTank[i], arrCoordinateHurdles))
                {
                    
                        if (direction == arrDirection[0])
                            arrPointsTank[i].Y -= 1 * tank.speed;
                        else if (direction == arrDirection[1])
                            arrPointsTank[i].Y += 1 * tank.speed;
                        else if (direction == arrDirection[2])
                            arrPointsTank[i].X -= 1 * tank.speed;
                        else if (direction == arrDirection[3])
                            arrPointsTank[i].X += 1 * tank.speed;
                    
                }
            }
            return arrPointsTank;
        }

        public bool checkCollisionTankObstacle(Point arrPointsTank, Point[] arrCoordinateObstacle)
        {
            //for (int j = 0; j < arrPointsTank.Length; j++)
            //{
                for (int i = 0; i < arrCoordinateObstacle.Length; i++)
                {
                    if (direction == "UP")
                    {
                        if (collides(arrPointsTank.X, arrPointsTank.Y, arrPointsTank.X + tank.sizeX, arrPointsTank.Y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16 + tank.speed))
                            return false;
                    }
                    if (direction == "DOWN")
                    {
                        if (collides(arrPointsTank.X, arrPointsTank.Y, arrPointsTank.X + tank.sizeX, arrPointsTank.Y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y - tank.speed, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))
                            return false;
                    }
                    if (direction == "LEFT")
                    {
                        if (collides(arrPointsTank.X - tank.speed, arrPointsTank.Y, arrPointsTank.X + tank.sizeX, arrPointsTank.Y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))
                            return false;
                    }
                    if (direction == "RIGHT")
                    {
                        if (collides(arrPointsTank.X, arrPointsTank.Y, arrPointsTank.X + tank.sizeX + tank.speed, arrPointsTank.Y + tank.sizeY, arrCoordinateObstacle[i].X, arrCoordinateObstacle[i].Y, arrCoordinateObstacle[i].X + 36, arrCoordinateObstacle[i].Y + 16))

                            return false;
                    }
                }

                //if (direction == arrDirection[0])
                //    arrPointsTank.Y -= 1 * tank.speed;
                //else if (direction == arrDirection[1])
                //    arrPointsTank.Y += 1 * tank.speed;
                //else if (direction == arrDirection[2])
                //    arrPointsTank.X -= 1 * tank.speed;
                //else if (direction == arrDirection[3])
                //    arrPointsTank.X += 1 * tank.speed;
                //if (j == arrPointsTank.Length - 1)

                //{
                //    return true;
                //}
           // }
            return true;
        }

    }
}
