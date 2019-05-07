using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Kolobok
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public int speed;
        public int score;


        public Kolobok(int X, int Y, int SizeX, int SizeY, int Speed, int Score)
        {
            x = X;
            y = Y;
            sizeX = SizeX;
            sizeY = SizeY;
            speed = Speed;
            score = Score;
        }
        public Kolobok()
        {
            x = 0;
            y = 0;
            sizeX = 0;
            sizeY = 0;
            speed = 1;
            score = 0;
    }
    }
}
