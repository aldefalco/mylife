using MyLife.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// Represents an interface for game data model
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Gets model persistent object
        /// </summary>
        IModelPersistent ModelPersistent { get; }

        /// <summary>
        /// Gets model editor
        /// </summary>
        IModelEditor ModelEditor { get; }

        /// <summary>
        /// Gets iterator for all live cells
        /// </summary>
        IEnumerable<Cell> Alive { get; }

        /// <summary>
        /// Start a new generation
        /// </summary>
        /// <returns>Generation instance</returns>
        IGeneration StartGeneration();

        /// <summary>
        /// Checks a cell for live
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        bool IsCellAlive(Cell cell);

        /// <summary>
        /// Clear all cells
        /// </summary>
        void Clear();

        /// <summary>
        /// Notify that model was changed
        /// </summary>
        event EventHandler Changed;
    }
}
