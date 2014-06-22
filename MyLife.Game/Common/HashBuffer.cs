using MyLife.Game.Data;
using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Common
{
    /// <summary>
    /// This is a simple cell buffer implenetation based on HashSet
    /// </summary>
    public class HashBuffer : ICellBag
    {
        public HashSet<Cell> cells = new HashSet<Cell>();

        public IEnumerable<Cell> Iterator
        {
            get { return cells; }
        }

        public void Fill(IEnumerable<Cell> cells)
        {
            this.cells = new HashSet<Cell>(cells);
        }
    }
}
