using DraughtsGameAPIService.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DraughtsGameAPIUnitTests
{
    [TestClass]
    public class TreeUnitTests
    {
        [TestMethod]
        public void TreeToArray_BasicTest()
        {
            //Associate 
            Tree tree = new Tree(new TreeTake
            {
                CurrentHeight = 1,
                CurrentWidth = 1
            });

            tree.Left = new Tree(new TreeTake
            {
                TakeHeight = 2,
                TakeWidth = 2,
                NextHeight = 2,
                NextWidth = 2,
            });

            tree.Right = new Tree(new TreeTake
            {
                TakeHeight = 3,
                TakeWidth = 3,
                NextHeight = 3,
                NextWidth = 3,
            });

            //Act
            List<List<TreeTake>> result = Tree.TreeToArray(tree);

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result.First().Last().TakeHeight);
            Assert.AreEqual(3, result.Last().Last().TakeHeight);
        }
    }
}
