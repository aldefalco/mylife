using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLife.Game;
using MyLife.Game.Worlds;

namespace MyLife.Test
{
    [TestClass]
    public class BasicWordTests
    {
        [TestMethod]
        public void TestSingle()
        {
            /* ...
             * .#.
             * ...
             * */
            var initCells = new Cell[] { new Cell(1, 1) };
            /* ...
             * ...
             * ...
             * */
            var finalCells = new Cell[] {  };
            var word = new SimpleWorld();
            word.Init(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.NextGeneration(), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(word, finalCells);
        }

        [TestMethod]
        public void TestBlock()
        {
            /* ....
             * .##.
             * .##.
             * ....
             * */
            var initCells = new Cell[] { new Cell(1, 1), new Cell(1, 2), new Cell(2, 1), new Cell(2, 2) };
            /* ....
           * .##.
           * .##.
           * ....
           * */
            var finalCells = new Cell[] { new Cell(1, 1), new Cell(1, 2), new Cell(2, 1), new Cell(2, 2) };
            var word = new SimpleWorld();
            word.Init(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.NextGeneration(), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(word, finalCells);
        }

        [TestMethod]
        public void TestSimpleBirth1()
        {
            /* ....
             * .##.
             * ..#.
             * ....
             * */
            var initCells = new Cell[] { new Cell(1, 1), new Cell(1, 2), new Cell(2, 2) };
            /* ....
           * .##.
           * .##.
           * ....
           * */
            var finalCells = new Cell[] { new Cell(1, 1), new Cell(1, 2), new Cell(2, 1), new Cell(2, 2) };
            var word = new SimpleWorld();
            word.Init(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.NextGeneration(), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(word, finalCells);
        }

        [TestMethod]
        public void TestSimpleBirth2()
        {
            /* ....
             * .#..
             * .##.
             * ....
             * */
            var initCells = new Cell[] { new Cell(1, 1), new Cell(2, 1), new Cell(2, 2) };
            /* ....
           * .##.
           * .##.
           * ....
           * */
            var finalCells = new Cell[] { new Cell(1, 1), new Cell(1, 2), new Cell(2, 1), new Cell(2, 2) };
            var word = new SimpleWorld();
            word.Init(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.NextGeneration(), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(word, finalCells);
        }
    }
}
