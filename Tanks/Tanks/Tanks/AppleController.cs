using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class AppleController
    {
        private int countApple = 5;

        public Point[] CreateArrCoordinateApple(Point[] arrCoordinateHurdles, Kolobok kolobok)
        {
            Point[] arrCoordinateApple = new Point[countApple];

            Random random = new Random();
            bool check = true;

            while (check)
            {
                for (int i = 0; i < arrCoordinateApple.Length; i++)
                {
                    arrCoordinateApple[i].X = random.Next(36, 684);
                    arrCoordinateApple[i].Y = random.Next(16, 560);
                }

                if (checkCollisApple(arrCoordinateApple, arrCoordinateHurdles))
                    continue;
                if (checkCollisApple(arrCoordinateApple, arrCoordinateApple))
                    continue;
                if (checkCollisApple(arrCoordinateApple, transfCoordKolToArr(kolobok)))
                    continue;
                check = false;
            }
            return arrCoordinateApple;
        }

        public Point[] AddApple(Point[] arrCoordinateApple, Point[] arrCoordinateHurdles, Kolobok kolobok)
        {
            Point[] arrCoordinateAppleNew = new Point[countApple];
            Random random = new Random();
            bool check = true;
            
            if (arrCoordinateApple.Length < countApple)
            {
                for (int i = 0; i < arrCoordinateApple.Length; i++)
                {
                    arrCoordinateAppleNew[i] = arrCoordinateApple[i];
                }
                while (check)
                {
                    for (int i = countApple - 1; i > arrCoordinateApple.Length - 1; i--)//Думал повторяющийся код обернуть в метод, но тут в условии знаки разные, поэтому не получилось
                    {
                        arrCoordinateAppleNew[i].X = random.Next(36, 684);
                        arrCoordinateAppleNew[i].Y = random.Next(16, 560);
                    }

                    if (checkCollisApple(arrCoordinateAppleNew, arrCoordinateHurdles))
                        continue;
                    if (checkCollisApple(arrCoordinateAppleNew, arrCoordinateAppleNew))
                        continue;
                    if (checkCollisApple(arrCoordinateAppleNew, transfCoordKolToArr(kolobok)))
                        continue;
                    check = false;
                }
                return arrCoordinateAppleNew;
            }
            return arrCoordinateApple;
        }

        public bool checkCollisApple(Point[] arrCoordApple, Point[] arrCoordOtherObject)
        {
            int n = 0;
            for (int i = 0; i < arrCoordApple.Length; i++)
            {
                for (int j = 0; j < arrCoordOtherObject.Length; j++)
                {
                    if (!collides(arrCoordApple[i].X, arrCoordApple[i].Y, arrCoordApple[i].X + 30, arrCoordApple[i].Y + 30, arrCoordOtherObject[j].X, arrCoordOtherObject[j].Y, arrCoordOtherObject[j].X + 40, arrCoordOtherObject[j].Y + 30) || ((arrCoordApple[i] == arrCoordOtherObject[j]) & (arrCoordApple.Length == arrCoordOtherObject.Length)))
                        n++;
                    else return true;
                    if (n == (arrCoordApple.Length * arrCoordOtherObject.Length))
                        return false;
                }
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
    }
}
