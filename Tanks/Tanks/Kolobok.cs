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

        public Kolobok(int X, int Y, int SizeX, int SizeY)
        {
            x = X;
            y = Y;
            sizeX = SizeX;
            sizeY = SizeY;
        }
        public Kolobok()
        {
            x = 0;
            y = 0;
            sizeX = 0;
            sizeY = 0;
        }
    }
}
