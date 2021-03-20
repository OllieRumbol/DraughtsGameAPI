using DraughtsGameAPIModels;
using DraughtsGameAPIService.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraughtsGameAPIUnitTests
{
    [TestClass]
    public class FindMoveUnitTests
    {
        [TestMethod]
        public void FindMoveFindAvailableMoves_BasicTest()
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
            int player = 1;

            //Act
            List<NextMove> results = FindMove.FindAvailableMoves(board, player);

            //Assert
            Assert.AreEqual(7, results.Count);
        }
    }
}
