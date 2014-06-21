using MyLife.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLife.Game.Worlds;

namespace MyLife.Test
{
    public static class Helpers
    {
        public static void CheckCells(SimpleWorld word, IEnumerable<Cell> cells)
        {
            //TODO: use set class methods to check the intersect
            var set = new HashSet<Cell>(cells);
            foreach (Cell cell in word.Cells)
            {
                Assert.IsTrue(set.Contains(cell), 
                    "Following cell exists in the word but it's not expected in result : {0} ", cell);
                set.Remove(cell);
            }
            Assert.AreEqual(0, set.Count, "Following {0} cells still exist in result: {1} ", set.Count, set);
        }

        public static List<Cell> Generate(string figure)
        {
            var res = new List<Cell> ();
            var lines = figure.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#')
                        res.Add(new Cell(i, j));
                }
            }

            return res;
        }
    

    }
}
