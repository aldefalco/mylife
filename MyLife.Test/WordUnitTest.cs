using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLife.Game.Interfaces;
using MyLife.Game.Models;

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

            var word = new BasicWorld(new HashModel()) as IWorld;
            word.Model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.Evolve(), "Wrong number of generation:{0}", word.Generation);
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
            
            var word = new BasicWorld(new HashModel()) as IWorld;
            word.Model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.Evolve(), "Wrong number of generation:{0}", word.Generation);
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
            var word = new BasicWorld(new HashModel()) as IWorld;
            word.Model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.Evolve(), "Wrong number of generation:{0}", word.Generation);
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
            var word = new BasicWorld(new HashModel()) as IWorld;
            word.Model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(word, initCells);
            Assert.AreEqual(1, word.Evolve(), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(word, finalCells);
        }
    }
}
