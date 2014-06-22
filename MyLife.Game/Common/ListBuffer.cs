using MyLife.Game.Data;
using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Common
{
    /// <summary>
    /// This is a simple cell buffer implenetation based on List. 
    /// </summary>
    class ListBuffer : ICellBag
    {
        public List<Cell> cells = new List<Cell>();

        public IEnumerable<Cell> Iterator
        {
            get { return cells; }
        }

        public void Fill(IEnumerable<Cell> cells)
        {
            this.cells = new List<Cell>(cells);
        }
    }
}
