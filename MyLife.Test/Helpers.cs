using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLife.Game.Models;
using MyLife.Game.Data;
using MyLife.Game.Common;

namespace MyLife.Test
{
    public static class Helpers
    {
        public static void CheckCells(IWorld word, ICellBag map)
        {
            var result = new HashSet<Cell>(map.Iterator);

            var wordMap = new HashBuffer();
            word.Model.ModelPersistent.Flush(wordMap, null);

            //TODO: use set class methods to check the intersect
            foreach (Cell cell in wordMap.Iterator)
            {
                Assert.IsTrue(result.Contains(cell),
                    "Following cell exists in the word but it's not expected in result : {0} ", cell);
                result.Remove(cell);
            }
            Assert.AreEqual(0, result.Count, "Following {0} cells still exist in result: {1} ", result.Count, result);
        }

        public static ICellBag Generate(string figure)
        {

            var res = new HashBuffer();
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
