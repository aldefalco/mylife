using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game
{
    public class Sector
    {
        public long X { get; set; }
        public long Y { get; set; }

        private List<BitArray> cells = new List<BitArray>();
        private Dictionary<int, int> cellsIndex = new Dictionary<int, int>();





    }
}
