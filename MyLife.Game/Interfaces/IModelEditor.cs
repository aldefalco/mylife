using MyLife.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// Represents an interface for interactive editing
    /// </summary>
    public interface IModelEditor : IDisposable
    {
        /// <summary>
        /// Sets cell on
        /// </summary>
        /// <param name="cell"></param>
        void Set(Cell cell);

        /// <summary>
        /// Sets cell off
        /// </summary>
        /// <param name="cell"></param>
        void Reset(Cell cell);

        /// <summary>
        /// Inverts cell state
        /// </summary>
        /// <param name="cell"></param>
        void Invert(Cell cell);

        /// <summary>
        /// Commits changes
        /// </summary>
        void Commit();
    }
}
