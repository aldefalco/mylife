using System;
using System.Collections.Generic;
namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// Conway's life game word public interface
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Executes new generation
        /// </summary>
        /// <returns>Current generation number</returns>
        int Evolve(IModel model);

        /// <summary>
        /// Current generation number
        /// </summary>
        int Generation { get; }
    }
}
