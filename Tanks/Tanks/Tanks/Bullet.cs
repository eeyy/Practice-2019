using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Bullet
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public int speed;
        public string direction;

        public Bullet(int X, int Y, int SizeX, int SizeY, int Speed, string Direction)
        {
            x = X;
            y = Y;
            sizeX = SizeX;
            sizeY = SizeY;
            speed = Speed;
            direction = Direction;
        }
    }
}
