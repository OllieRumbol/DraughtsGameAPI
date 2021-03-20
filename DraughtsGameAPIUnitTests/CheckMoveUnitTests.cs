using DraughtsGameAPIService.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraughtsGameAPIUnitTests
{
    [TestClass]
    public class CheckMoveUnitTests
    {
        [TestMethod]
        public void CheckMove_CheckKingTake()
        {
            //Associate
            int[,] board = new int[,] {
                { 0, 2, 0, 2, 0, 2, 0, 2 },
                { 2, 0, 2, 0, 2, 0, 2, 0 },
                { 0, 2, 0, 2, 0, 2, 0, 2 },
                { 5, 0, 5, 0, 5, 0, 5, 0 },
                { 0, 5, 0, 5, 0, 5, 0, 5 },
                { 1, 0, 1, 0, 1, 0, 1, 0 },
                { 0, 1, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0 },
            };

            //Act

            KingTree tree = new KingTree(new TreeTake
            {
                CurrentHeight = 1,
                CurrentWidth = 1
            });

            //Assert
        }
    }
}
