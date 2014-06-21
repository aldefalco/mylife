using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Worlds
{
    /// <summary>
    /// This is a simple implementaion of the Conway's life game word based on hash sets
    /// </summary>
    public class SimpleWorld : IWorld
    {
        private int generation = 0;
        private HashSet<Cell> deadSet = new HashSet<Cell>();
        private HashSet<Cell> liveSet = new HashSet<Cell>();
        private HashSet<Cell> generationSet = new HashSet<Cell>();
        private readonly List<Cell> neighbours = null;

        public SimpleWorld()
        {
            neighbours = (from i in Enumerable.Range(-1, 3)
                         from j in Enumerable.Range(-1, 3)
                         where !(i == 0 && j == 0)
                         select new Cell(i, j)).ToList();
        }

        public void Init(IEnumerable<Cell> cells)
        {
            liveSet = new HashSet<Cell>(cells);
            // For memory allocation purposes
            deadSet = new HashSet<Cell>(cells);
            deadSet.Clear();
            generationSet = new HashSet<Cell>(cells);
            generationSet.Clear();
        }

        public IEnumerable<Cell> Cells 
        {
            get { return this.liveSet; }
        }

        public int Generation { get { return generation; } }

        public int NextGeneration()
        {
            generationSet.Clear();
            deadSet.Clear();

            foreach (var cell in liveSet)
            {
                if (IsAlive(cell))
                {
                    generationSet.Add(cell);
                }
            }

            foreach (var cell in deadSet)
            {
                if (IsRevival(cell))
                {
                    generationSet.Add(cell);
                }
            }

            var swap = liveSet;
            liveSet = generationSet;
            generationSet = swap;
            return ++generation;
        }

        private bool IsRevival(Cell cell)
        {
            return neighbours.Count(offset => IsCellAlive(cell, offset.X, offset.Y, false) ) == 3;
        }

        private bool IsAlive(Cell cell)
        {
            var neighbourCount = neighbours.Count(offset => IsCellAlive(cell, offset.X, offset.Y, true));
            return neighbourCount >= 2 && neighbourCount < 4;
        }

        private bool IsCellAlive(Cell cell, long x, long y, bool collectDead = true)
        {
            cell.Offset(x, y);
            if (liveSet.Contains(cell))
            {
                return true;
            }
            else
            {
                if (collectDead)
                    deadSet.Add(cell);
                return false;
            }
        }


        public void Set(Cell cell)
        {
            liveSet.Add(cell);
        }

        public void Invert(Cell cell)
        {
            if (liveSet.Contains(cell))
                liveSet.Remove(cell);
            else
                liveSet.Add(cell);
        }
    }
}
