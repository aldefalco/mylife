using System;
using System.Collections.Generic;
namespace MyLife.Game.Worlds
{
    /// <summary>
    /// Conway's life game word public interface
    /// </summary>
    public interface IWorld
    {
        /// <summary>
        /// Get cell's enumerator
        /// </summary>
        IEnumerable<Cell> Cells { get; }
        /// <summary>
        /// Get current generation
        /// </summary>
        int Generation { get; }
        /// <summary>
        /// Initialize a new world with live cells
        /// </summary>
        /// <param name="cells">Live cells enumeration</param>
        void Init(IEnumerable<Cell> cells);
        /// <summary>
        /// Execute the next turn of generation
        /// </summary>
        /// <returns>Returns the number of current generation</returns>
        int NextGeneration();
        /// <summary>
        /// Set the cell to alive
        /// </summary>
        /// <param name="cell">The cell of game</param>
        void Set(Cell cell);
        /// <summary>
        /// Invert cell state, if the cell is alive it dies and if the cell is dead it relives
        /// </summary>
        /// <param name="cell">The cell of game</param>
        void Invert(Cell cell);

    }
}
