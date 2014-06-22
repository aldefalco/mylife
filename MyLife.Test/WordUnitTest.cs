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

            var word = new BasicWorld() as IGame;
            var model = new HashModel();
            model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(model, initCells);
            Assert.AreEqual(1, word.Evolve(model), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(model, finalCells);
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

            var word = new BasicWorld() as IGame;
            var model = new HashModel();
            model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(model, initCells);
            Assert.AreEqual(1, word.Evolve(model), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(model, finalCells);
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
            var word = new BasicWorld() as IGame;
            var model = new HashModel();
            model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(model, initCells);
            Assert.AreEqual(1, word.Evolve(model), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(model, finalCells);
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
            var word = new BasicWorld() as IGame;
            var model = new HashModel();
            model.ModelPersistent.Initialize(initCells);
            Helpers.CheckCells(model, initCells);
            Assert.AreEqual(1, word.Evolve(model), "Wrong number of generation:{0}", word.Generation);
            Helpers.CheckCells(model, finalCells);
        }
    }
}
