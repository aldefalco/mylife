﻿using MyLife.Game.Data;
using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Worlds
{
    /// <summary>
    /// This is a simple implementaion algorithm of the Conway's life game.
    /// It's not thread-safe and works on sync mode.
    /// </summary>
    public class BasicWorld : IGame
    {
        private int generation = 0;
 
        /// <summary>
        /// Offset collection for 8 neighbours
        /// </summary>
        private readonly List<Cell> neighbours = null;

        public BasicWorld()
        {
            neighbours = (from i in Enumerable.Range(-1, 3)
                         from j in Enumerable.Range(-1, 3)
                         where !(i == 0 && j == 0)
                         select new Cell(i, j)).ToList();
        }

        public int Generation { get { return generation; } }

        public int Evolve(IModel model)
        {
            using (var gen = model.StartGeneration())
            {
                // Checks all alive neighbors for live criteria and collect all possible dead cells
                Func<Cell, bool> CheckNearbyAlive = (c) =>
                {
                    var neighbourDead = neighbours.Where(offset => !model.IsCellAlive(c.Offset(offset.X, offset.Y)))
                        .Select(offset => c.Offset(offset.X, offset.Y));
                    var aliveCount = 8 - gen.CollectDead(neighbourDead);
                    return aliveCount >= 2 && aliveCount < 4;
                };

                // Checks all live neighbors of dead cell for parent criteria 
                Func<Cell, bool> CheckNearbyParents = (c) =>
                {
                    return neighbours.Count(offset => model.IsCellAlive(c.Offset(offset.X, offset.Y))) == 3;
                };

                //TODO: change to LINQ
                // Collect all alive cells
                foreach (var cell in model.Alive)
                {
                    if (CheckNearbyAlive(cell))
                    {
                        gen.CollectAlive(cell);
                    }
                }

                // Collect all releve cells
                foreach (var cell in gen.Dead)
                {
                    if (CheckNearbyParents(cell))
                    {
                        gen.CollectAlive(cell);
                    }
                }

                gen.Commit();
            }

            return ++generation;
        }
    }
}
