﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks
{
    class PackmanController
    {
        private Point RemovedApple = Point.Empty;
        private Point coordinatesKolobok = Point.Empty;
        private string[] arrDirection =
        {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"
        };
        private static int x = 37;
        private static int y = 317;
        private static int width = 40;
        private static int height = 40;
        private static int speed = 4;
        private static int score = 0;
        private static string direction = "RIGHT";

        public Point[] arrCoordinateHurdles = new Point[122];
        public Point[] arrCoordinateRiver = new Point[27];
        public Point[] arrCoordinateMonolith = new Point[78];


        public Kolobok kolobok = new Kolobok(x, y, width, height, speed, score, direction);


        public void ResetKolobok()
        {
            kolobok = new Kolobok(x, y, width, height, speed, score, direction);
        }
            
        //Движение колобка
        public void GoKolobok()
        {
            Point sizeHurdles = new Point { X = 36, Y = 16 };
            Point sizeMonolith = new Point { X = 36, Y = 32 };

            if (checkCollisionKolHurd(arrCoordinateHurdles, sizeHurdles) & checkCollisionKolHurd(arrCoordinateRiver, sizeHurdles) & checkCollisionKolHurd(arrCoordinateMonolith, sizeMonolith))
            {
                if (kolobok.direction == arrDirection[0])
                    kolobok.y -= kolobok.speed;
                else if (kolobok.direction == arrDirection[1])
                    kolobok.y += kolobok.speed;
                else if (kolobok.direction == arrDirection[2])
                    kolobok.x -= kolobok.speed;
                else if (kolobok.direction == arrDirection[3])
                    kolobok.x += kolobok.speed;
            }
        }


        public void KeyDown(Keys keys)
        {
            if (keys == Keys.Down)
            {
                kolobok.direction = arrDirection[1];
            }
            if (keys == Keys.Up)
            {
                kolobok.direction = arrDirection[0];
            }
            if (keys == Keys.Right)
            {
                kolobok.direction = arrDirection[3];
            }
            if (keys == Keys.Left)
            {
                kolobok.direction = arrDirection[2];
            }
        }

        public Point GetCoodinateKolobok()
        {
            coordinatesKolobok.X = kolobok.x;
            coordinatesKolobok.Y = kolobok.y;
            return coordinatesKolobok;
        }

        //Создание речки
        public Point[] CreateArrCoordinateRiver()
        {
            int x = 468;
            int y = 430;
            for (int i = 0; i < 9; i++)
            {
                arrCoordinateRiver[i].X = x;
                arrCoordinateRiver[i].Y = y;
                x += 24;
            }
            x = 468;
            y = 450;
            for (int i = 9; i < 18; i++)
            {
                arrCoordinateRiver[i].X = x;
                arrCoordinateRiver[i].Y = y;
                x += 24;
            }
            x = 468;
            y = 470;
            for (int i = 18; i < 27; i++)
            {
                arrCoordinateRiver[i].X = x;
                arrCoordinateRiver[i].Y = y;
                x += 24;
            }
            return arrCoordinateRiver;
        }


        //Создание монолитных стен
        public Point[] CreateArrCoordinateMonolith()
        {
            int y = 0;
            int x = 0;
            //Создание клетки
            for (int i = 0; i < 19; i++)
            {
                arrCoordinateMonolith[i].X = x;
                arrCoordinateMonolith[i].Y = y;
                y += 32;
            }
            y = 0;
            for (int i = 20; i < 39; i++)
            {
                arrCoordinateMonolith[i].X = x;
                arrCoordinateMonolith[i].Y = y;
                x += 36;
            }

            y = 0;

            for (int i = 40; i < 58; i++)
            {
                arrCoordinateMonolith[i].X = x;
                arrCoordinateMonolith[i].Y = y;
                y += 32;
            }

            x = 36;
            for (int i = 59; i < 78; i++)
            {
                arrCoordinateMonolith[i].X = x;
                arrCoordinateMonolith[i].Y = y;
                x += 36;
            }
            return arrCoordinateMonolith;
        }

        //Создание разрушаемых стен
        public Point[] CreateArrCoordinateHurdles()
        {
            int y = 0;
            int x = 0;
            arrCoordinateHurdles = new Point[122];

            //Создание препятствий сверху
            y = 500;
            x = 0;
            for (int i = 0; i < 8; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 216;
            y = 32;
            for (int i = 8; i < 16; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 288;
            y = 48;
            for (int i = 16; i < 20; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 288;
            y = 64;
            for (int i = 20; i < 24; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 288;
            y = 80;
            for (int i = 24; i < 28; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }

            //Создание препятствий слева
            x = 36;
            y = 160;
            for (int i = 28; i < 34; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 36;
            y = 176;
            for (int i = 34; i < 40; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 216;
            y = 176;
            for (int i = 40; i < 46; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 72;
            y = 436;
            for (int i = 46; i < 50; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 108;
            y = 436;
            for (int i = 50; i < 54; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 144;
            y = 420;
            for (int i = 54; i < 59; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 180;
            y = 420;
            for (int i = 59; i < 64; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 108;
            y = 176;
            for (int i = 64; i < 74; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }

            //Создание препятствий справа
            x = 360;
            y = 176;
            for (int i = 74; i < 93; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 540;
            y = 176;
            for (int i = 93; i < 103; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 360;
            y = 336;
            for (int i = 103; i < 110; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 360;
            y = 350;
            for (int i = 110; i < 117; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            //x = 468;
            //y = 430;
            //for (int i = 229; i < 235; i++)
            //{
            //    arrCoordinateHurdles[i].X = x;
            //    arrCoordinateHurdles[i].Y = y;
            //    x += 36;
            //}
            //x = 468;
            //y = 430;
            //for (int i = 235; i < 240; i++)
            //{
            //    arrCoordinateHurdles[i].X = x;
            //    arrCoordinateHurdles[i].Y = y;
            //    y += 16;
            //}
            //x = 504;
            //y = 96;
            //for (int i = 240; i < 245; i++)
            //{
            //    arrCoordinateHurdles[i].X = x;
            //    arrCoordinateHurdles[i].Y = y;
            //    x += 36;
            //}
            //Добавить в левый верхний угол
            x = 36;
            y = 96;
            for (int i = 117; i < 122; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }

            return arrCoordinateHurdles;
        }
        
        public void SetArrCoordinateHurdles(Point[] points)
        {
            arrCoordinateHurdles = points;
        }



        //Взаимодействие с препятствием
        public bool checkCollisionKolHurd(Point[] arrCoordinateHurdles, Point sizeObstacle)
        {
            for (int i = 0; i < arrCoordinateHurdles.Length; i++)
            {
                if (kolobok.direction == "UP")
                {
                    if (collides(kolobok.x, kolobok.y, kolobok.x + kolobok.sizeX, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y, arrCoordinateHurdles[i].X + sizeObstacle.X, arrCoordinateHurdles[i].Y + sizeObstacle.Y + speed))
                        return false;
                }
                if (kolobok.direction == "DOWN")
                {
                    if (collides(kolobok.x, kolobok.y, kolobok.x + kolobok.sizeX, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y - speed, arrCoordinateHurdles[i].X + sizeObstacle.X, arrCoordinateHurdles[i].Y + sizeObstacle.Y))
                        return false;
                }
                if (kolobok.direction == "LEFT")
                {
                    if (collides(kolobok.x - speed + 1, kolobok.y, kolobok.x + kolobok.sizeX, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y, arrCoordinateHurdles[i].X + sizeObstacle.X, arrCoordinateHurdles[i].Y + sizeObstacle.Y))
                        return false;
                }
                if (kolobok.direction == "RIGHT")
                {
                    if (collides(kolobok.x, kolobok.y, kolobok.x + kolobok.sizeX + speed + 2, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y, arrCoordinateHurdles[i].X + sizeObstacle.X, arrCoordinateHurdles[i].Y + sizeObstacle.Y))
                        return false;
                }

                if (i == arrCoordinateHurdles.Length - 1)
                {
                    return true;
                }
            }
            return true;
        }
        


        //Сбор яблок
        public Point[] CheckEatKolobok(Point[] arrPointsApple)
        {
            for (int i = 0; i < arrPointsApple.Length; i++)
            {
                if (collides(kolobok.x, kolobok.y, kolobok.x + kolobok.sizeX, kolobok.y + kolobok.sizeY, arrPointsApple[i].X, arrPointsApple[i].Y, arrPointsApple[i].X + 36, arrPointsApple[i].Y + 30))
                {
                    RemovedApple = arrPointsApple[i];
                    var arrToList = new List<Point>(arrPointsApple);
                    arrToList.RemoveAt(i);
                    arrPointsApple = arrToList.ToArray();
                    kolobok.score++;
                }
            }
            return arrPointsApple;
        }

        public Point RemoveApple()
        {
            return RemovedApple;
        }

        public PictureBox BangKolobok(PictureBox pictureBox)
        {
            //Point coordKolobok = new Point();
            //coordKolobok
            KolobokView kolobokView = new KolobokView();
            return kolobokView.GameOver(GetCoodinateKolobok(), pictureBox);
        }


        public bool collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x > r2 ||
                     b <= y2 || y > b2);
        }

    }
}
