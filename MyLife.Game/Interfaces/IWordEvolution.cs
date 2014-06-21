using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    public interface IWorldEvolution
    {
        int Evolve();
        int Revolution(int turns);
        int Generation { get; }
    }
}
