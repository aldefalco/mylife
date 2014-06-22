using MyLife.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// Represents an interace for new generation processing. It uses the IDisposable to complete the process and fix
    /// generation in model.
    /// </summary>
    public interface IGeneration : IDisposable
    {
        /// <summary>
        /// Adds the cell to generation
        /// </summary>
        /// <param name="cell">Cell</param>
        void CollectAlive(Cell cell);

        /// <summary>
        /// Adds cell to dead collection that nearby for live
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        int CollectDead(IEnumerable<Cell> cells);

        /// <summary>
        /// Gets iterator for dead cells that nearby for live
        /// </summary>
        IEnumerable<Cell> Dead { get; }

        void Commit();
    }
}
