using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLife.Game.Interfaces;
using MyLife.Game.Worlds;

namespace MyLife.Test
{
    [TestClass]
    public class BasicWordTests
    {
        [TestMethod]
        public void TestSingle()
        {
            var initCells = Helpers.Generate(@"
                                               ......
                                               .#....
                                               ......
                                               ......");

            var finalCells = Helpers.Generate(@"
                                               ......
                                               ......
                                               ......
                                               .......");

            var word = new SimpleWorld() as IWorld;
            word.WorldPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.WorldEvolution.Evolve(), "Wrong number of generation:{0}", word.WorldEvolution.Generation);
            Helpers.CheckCells(word, finalCells);
        }

        [TestMethod]
        public void TestBlock()
        {
            var initCells = Helpers.Generate(@"
                                               ......
                                               .##...
                                               .##...
                                               ......");

            var finalCells = Helpers.Generate(@"
                                               ......
                                               .##...
                                               .##...
                                               .......");
            
            var word = new SimpleWorld() as IWorld;
            word.WorldPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.WorldEvolution.Evolve(), "Wrong number of generation:{0}", word.WorldEvolution.Generation);
            Helpers.CheckCells(word, finalCells);
        }

        [TestMethod]
        public void TestSimpleBirth1()
        {
            var initCells = Helpers.Generate(@"
                                               ......
                                               ..##..
                                               ...#..
                                               ......");

            var finalCells = Helpers.Generate(@"
                                               ......
                                               ..##..
                                               ..##..
                                               .......");
            var word = new SimpleWorld() as IWorld;
            word.WorldPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.WorldEvolution.Evolve(), "Wrong number of generation:{0}", word.WorldEvolution.Generation);
            Helpers.CheckCells(word, finalCells);
        }

        [TestMethod]
        public void TestSimpleBirth2()
        {
            var initCells = Helpers.Generate(@"
                                               ......
                                               ......
                                               .#....
                                               .##...");

            var finalCells = Helpers.Generate(@"
                                               ......
                                               ......
                                               .##...
                                               .##....");
            var word = new SimpleWorld() as IWorld;
            word.WorldPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.WorldEvolution.Evolve(), "Wrong number of generation:{0}", word.WorldEvolution.Generation);
            Helpers.CheckCells(word, finalCells);
        }
    }
}
