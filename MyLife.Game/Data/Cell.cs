using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Data
{
    /// <summary>
    /// A cell in the life game world
    /// </summary>
    public struct Cell
    {
        public long X;
        public long Y;

        public Cell(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }

        public Cell Offset(long x, long y)
        {
            return new Cell(this.X + x, this.Y + y);
            /*
            this.X += x;
            this.Y += y;
             * */
        }

        public override string ToString()
        {
            return string.Format("[X={0}, Y={1}]", X, Y);
        }
    }
}
