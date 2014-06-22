using System;
using System.Collections.Generic;
namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// Conway's life game word public interface
    /// </summary>
    public interface IWorld
    {
        /// <summary>
        /// Gets word model
        /// </summary>
        IModel Model { get; }

        /// <summary>
        /// Executes new generation
        /// </summary>
        /// <returns>Current generation number</returns>
        int Evolve();

        /// <summary>
        /// Current generation number
        /// </summary>
        int Generation { get; }
    }
}
