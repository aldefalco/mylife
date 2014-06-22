using MyLife.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// Represents an interface for a buffer or a storage of cells
    /// </summary>
    public interface ICellBag
    {
        /// <summary>
        /// Gets iterator for all cells in the bag
        /// </summary>
        IEnumerable<Cell> Iterator { get; }
        
        /// <summary>
        /// Fill the bag from other iterator
        /// </summary>
        /// <param name="cells">Cells iterator</param>
        void Fill(IEnumerable<Cell> cells);
    }
}
