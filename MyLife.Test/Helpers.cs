using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLife.Game.Worlds;
using MyLife.Game.Data;

namespace MyLife.Test
{
    public static class Helpers
    {
        class MapSet : IMap
        {
            public HashSet<Cell> cells;

            public IEnumerable<Cell> Iterator
            {
                get { return cells; }
            }

            public void Commit(IEnumerable<Cell> cells)
            {
                this.cells = new HashSet<Cell>(cells);
            }
        }

        class MapList : IMap
        {
            public List<Cell> cells = new List<Cell>();

            public IEnumerable<Cell> Iterator
            {
                get { return cells;  }
            }

            public void Commit(IEnumerable<Cell> cells)
            {
                this.cells = new List<Cell>(cells);
            }
        }

        /*
        public static void CheckCells(IWorld word, IEnumerable<Cell> cells)
        {
            var result = new HashSet<Cell>(cells);
            var map = new MapSet();
            word.WorldPersistent.Flush(map, null);

            //TODO: use set class methods to check the intersect
            foreach (Cell cell in map.cells)
            {
                Assert.IsTrue(result.Contains(cell), 
                    "Following cell exists in the word but it's not expected in result : {0} ", cell);
                result.Remove(cell);
            }
            Assert.AreEqual(0, result.Count, "Following {0} cells still exist in result: {1} ", result.Count, result);
        }
         * */

        public static void CheckCells(IWorld word, IMap map)
        {
            var result = new HashSet<Cell>(map.Iterator);

            var wordMap = new MapSet();
            word.WorldPersistent.Flush(wordMap, null);

            //TODO: use set class methods to check the intersect
            foreach (Cell cell in wordMap.Iterator)
            {
                Assert.IsTrue(result.Contains(cell),
                    "Following cell exists in the word but it's not expected in result : {0} ", cell);
                result.Remove(cell);
            }
            Assert.AreEqual(0, result.Count, "Following {0} cells still exist in result: {1} ", result.Count, result);
        }

        public static IMap Generate(string figure)
        {

            var res = new MapList();
            var lines = figure.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#')
                        res.cells.Add(new Cell(i, j));
                }
            }

            return res;
        }
    

    }
}
