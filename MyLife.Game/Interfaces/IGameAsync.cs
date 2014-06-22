using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// Asy
    /// </summary>
    public interface IGameAsync : IGame
    {
        void EvolveAsync(IModel model, Action complete);
    }
}
