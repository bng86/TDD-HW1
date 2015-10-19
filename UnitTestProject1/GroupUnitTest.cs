using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strore;

namespace UnitTestProject1
{
    [TestClass]
    public class GroupUnitTest
    {
        private List<Product> Products { get; set; }

        [TestInitialize]
        public void Init()
        {
            Products = new List<Product>
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
            };
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            Products = null;
        }

        [TestMethod]
        public void GetGroupPriceList_三筆一組_取Cost總和列表()
        {
            //arrange
            var target = new Group(Products);
            var groupSize = 3;
            var field = GroupField.Cost;
            var expected = new List<int> { 6, 15, 24, 21 };
            //act
            var actual = target.GetGroupPriceList(field, groupSize);
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGroupPriceList_四筆一組_取Revenue總和列表()
        {
            //arrange
            var target = new Group(Products);
            var groupSize = 4;
            var field = GroupField.Revenue;
            var expected = new List<int> { 50, 66, 60 };
            //act
            var actual = target.GetGroupPriceList(field, groupSize);
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
