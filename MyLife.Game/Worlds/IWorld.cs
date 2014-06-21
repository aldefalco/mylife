using System;
namespace MyLife.Game.Worlds
{
    interface IWorld
    {
        System.Collections.Generic.IEnumerable<Cell> Cells { get; }
        int Generation { get; }
        void Init(System.Collections.Generic.IEnumerable<Cell> cells);
        int NextGeneration();
    }
}
