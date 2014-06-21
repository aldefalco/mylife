using MyLife.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    public interface IWorldEditor
    {
        void Set(Cell cell);
        void Reset(Cell cell);
        void Invert(Cell cell);
        void Commit();
        void Cancel();
    }
}
