using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Tank
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public int speed;


        public Tank(int X, int Y, int SizeX, int SizeY, int Speed)
        {
            x = X;
            y = Y;
            sizeX = SizeX;
            sizeY = SizeY;
            speed = Speed;
        }
        public Tank()
        {
            x = 0;
            y = 0;
            sizeX = 0;
            sizeY = 0;
            speed = 1;
        }
    }
}
