using DraughtsGameAPIService.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DraughtsGameAPIUnitTests
{
    [TestClass]
    public class KingTreeUnitTests
    {
        [TestMethod]
        public void KingTreeToArray_BasicTest()
        {
            //Associate 
            KingTree tree = new KingTree(new TreeTake
            {
                CurrentHeight = 1,
                CurrentWidth = 1
            });

            tree.DownLeft = new KingTree(new TreeTake
            {
                TakeHeight = 2,
                TakeWidth = 2,
                NextHeight = 2,
                NextWidth = 2,
            });

            tree.DownRight = new KingTree(new TreeTake
            {
                TakeHeight = 3,
                TakeWidth = 3,
                NextHeight = 3,
                NextWidth = 3,
            });

            tree.UpLeft = new KingTree(new TreeTake
            {
                TakeHeight = 4,
                TakeWidth = 4,
                NextHeight = 4,
                NextWidth = 4,
            });

            tree.UpRight = new KingTree(new TreeTake
            {
                TakeHeight = 5,
                TakeWidth = 5,
                NextHeight = 5,
                NextWidth = 5,
            });

            //Act
            List<List<TreeTake>> result = KingTree.KingTreeToArray(tree);

            //Assert
            Assert.AreEqual(4, result.Count);
        }
    }
}
