using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strore;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetPriceSum_sum_of_cost_group_size_3()
        {
            //arrange
            var target = new Sell();
            var groupSize = 3;
            var costs = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var expected = new List<int> {6, 15, 24, 21};
            //act
            var actual = target.GetPriceSum(costs, groupSize);
            //assert
            CollectionAssert.AreEqual(expected, actual);

        }

        

        [TestMethod]
        public void GetPriceSum_sum_of_revenue_group_size_4()
        {
            //arrange
            var target = new Sell();
            var groupSize = 4;
            var revenue = new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
            var expected = new List<int> { 50, 66, 60 };
            //act
            var actual = target.GetPriceSum(revenue, groupSize);
            //assert
            CollectionAssert.AreEqual(expected, actual);

        }
    }
}
