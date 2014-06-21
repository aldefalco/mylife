using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game
{
    public struct Cell
    {
        public long X;
        public long Y;

        public Cell(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Offset(long x, long y)
        {
            this.X += x;
            this.Y += y;
        }

        public override string ToString()
        {
            return string.Format("[X={0}, Y={1}]", X, Y);
        }
    }
}
