using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class PackmanController
    {
        private Point coordinates = Point.Empty;
        private string direction = "RIGHT";
        private string[] arrDirection =
        {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"
        };
        public static int x = 37;
        public static int y = 317;
        public static int width = 40;
        public static int height = 40;
        public int speed = 3;


        private Point[] arrCoordinateHurdles = new Point[300];
        Kolobok kolobok = new Kolobok(x, y, width, height);




        public void GoKolobok()
        {
            if (checkForCollision(arrCoordinateHurdles))
            {
                if (direction == arrDirection[0])
                    kolobok.y -= 1 * speed;
                else if (direction == arrDirection[1])
                    kolobok.y += 1 * speed;
                else if (direction == arrDirection[2])
                    kolobok.x -= 1 * speed;
                else if (direction == arrDirection[3])
                    kolobok.x += 1 * speed;
            }
        }


        public void KeyDown(Keys keys)
        {
            if (keys == Keys.Down)
            {
                direction = arrDirection[1];
            }
            if (keys == Keys.Up)
            {
                direction = arrDirection[0];
            }
            if (keys == Keys.Right)
            {
                direction = arrDirection[3];
            }
            if (keys == Keys.Left)
            {
                direction = arrDirection[2];
            }
        }

        public Point GetCoodinateKolobok()
        {
            coordinates.X = kolobok.x;
            coordinates.Y = kolobok.y;
            return coordinates;
        }

        public Point[] CreateArrCoordinateHurdles()
        {
            int y = 0;
            int x = 0;
            //Создание клетки
            for (int i = 0; i < 37; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            y = 0;
            for (int i = 37; i < 56; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }

            y = 0;

            for (int i = 56; i < 93; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }

            y -= 16;
            x = 36;
            for (int i = 93; i < 112; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }

            //Создание препятствий сверху
            x = 216;
            y = 16;
            for (int i = 112; i < 120; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 216;
            y = 32;
            for (int i = 120; i < 128; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 288;
            y = 48;
            for (int i = 128; i < 132; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 288;
            y = 64;
            for (int i = 132; i < 136; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 288;
            y = 80;
            for (int i = 136; i < 140; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }

            //Создание препятствий слева
            x = 36;
            y = 160;
            for (int i = 140; i < 146; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 36;
            y = 176;
            for (int i = 146; i < 152; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 216;
            y = 176;
            for (int i = 152; i < 158; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 72;
            y = 436;
            for (int i = 158; i < 162; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 108;
            y = 436;
            for (int i = 162; i < 166; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 144;
            y = 388;
            for (int i = 166; i < 171; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 180;
            y = 388;
            for (int i = 171; i < 176; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 108;
            y = 176;
            for (int i = 176; i < 186; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }

            //Создание препятствий справа
            x = 360;
            y = 176;
            for (int i = 186; i < 205; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 540;
            y = 176;
            for (int i = 205; i < 215; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 360;
            y = 336;
            for (int i = 215; i < 222; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 360;
            y = 350;
            for (int i = 222; i < 229; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 468;
            y = 430;
            for (int i = 229; i < 235; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            x = 468;
            y = 446;
            for (int i = 235; i < 240; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                y += 16;
            }
            x = 504;
            y = 96;
            for (int i = 240; i < 245; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }
            //Добавить в левый верхний угол
            x = 36;
            y = 96;
            for (int i = 245; i < 250; i++)
            {
                arrCoordinateHurdles[i].X = x;
                arrCoordinateHurdles[i].Y = y;
                x += 36;
            }

            return arrCoordinateHurdles;
        }
        
        public Point[] CreateArrCoordinateApple() //не до конца правильно проверяет
        {
            Point[] arrCoordinateApple = new Point[5];
            Random random = new Random();
            int check = 0;
            
            while (check < 2)
            {
                int n = 0;
                for (int i = 0; i < arrCoordinateApple.Length; i++)
                {
                    
                    arrCoordinateApple[i].X = random.Next(36, 684);
                    arrCoordinateApple[i].Y = random.Next(16, 560);
                }
                for (int i = 0; i < arrCoordinateApple.Length; i++)
                {
                    for (int j = 0; j < arrCoordinateHurdles.Length; j++)
                    {
                        if (!collides(arrCoordinateApple[i].X, arrCoordinateApple[i].Y, arrCoordinateApple[i].X + 30, arrCoordinateApple[i].Y + 30, arrCoordinateHurdles[j].X, arrCoordinateHurdles[j].Y, arrCoordinateHurdles[j].X + 36, arrCoordinateHurdles[j].Y + 16))
                            n++;
                        if (n == (arrCoordinateApple.Length * arrCoordinateHurdles.Length))
                            check++;
                    }
                }
                n = 0;
                for (int i = 0; i < arrCoordinateApple.Length; i++)
                {
                    for (int j = 1; j < arrCoordinateApple.Length; j++)
                    {
                        if (!collides(arrCoordinateApple[i].X, arrCoordinateApple[i].Y, arrCoordinateApple[i].X + 30, arrCoordinateApple[i].Y + 30, arrCoordinateApple[j].X, arrCoordinateApple[j].Y, arrCoordinateApple[j].X + 30, arrCoordinateApple[j].Y + 30))
                            n++;
                        if (n == (arrCoordinateApple.Length * arrCoordinateApple.Length))
                            check++;
                    }
                }
            }
            return arrCoordinateApple;
        }
        

        public bool checkForCollision(Point[] arrCoordinateHurdles)
        {
            for (int i = 0; i < arrCoordinateHurdles.Length; i++)
            {
                if (direction == "UP")
                {
                    if (collides(kolobok.x, kolobok.y, kolobok.x + kolobok.sizeX, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y, arrCoordinateHurdles[i].X + 36, arrCoordinateHurdles[i].Y + 16 + speed))
                        return false;
                }
                if (direction == "DOWN")
                {
                    if (collides(kolobok.x, kolobok.y, kolobok.x + kolobok.sizeX, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y - speed, arrCoordinateHurdles[i].X + 36, arrCoordinateHurdles[i].Y + 16))
                        return false;
                }
                if (direction == "LEFT")
                {
                    if (collides(kolobok.x - speed, kolobok.y, kolobok.x + kolobok.sizeX, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y, arrCoordinateHurdles[i].X + 36, arrCoordinateHurdles[i].Y + 16))
                        return false;
                }
                if (direction == "RIGHT")
                {
                    if (collides(kolobok.x, kolobok.y, kolobok.x + kolobok.sizeX + speed, kolobok.y + kolobok.sizeY, arrCoordinateHurdles[i].X, arrCoordinateHurdles[i].Y, arrCoordinateHurdles[i].X + 36, arrCoordinateHurdles[i].Y + 16))
                        return false;
                }

                if (i == arrCoordinateHurdles.Length - 1)
                {
                    return true;
                }
            }
            return true;
        }

        public bool collides(int x, int y, int r, int b, int x2, int y2, int r2, int b2)
        {
            return !(r <= x2 || x > r2 ||
                     b <= y2 || y > b2);
        }

    }
}
