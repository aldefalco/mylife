using MyLife.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    public interface IMap
    {
        IEnumerable<Cell> Iterator { get; }
        void Commit(IEnumerable<Cell> cells);
    }
}
