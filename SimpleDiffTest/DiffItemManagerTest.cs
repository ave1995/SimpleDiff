using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleDiff.Diff;
using SimpleDiff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDiffTest
{
    [TestClass]
    public class DiffItemManagerTest
    {
        private DiffItemManager _diffItemManager;
        private Mock<IDiffItemStore> _diffItemStoreMock;
        public DiffItemManagerTest()
        {
            _diffItemStoreMock = new Mock<IDiffItemStore>();
            _diffItemManager = new DiffItemManager(_diffItemStoreMock.Object);
        }


        [TestMethod]
        public async Task DifferentSize()
        {
            _diffItemStoreMock.Setup(s => s.FindItemsById(It.IsAny<int>(), default)).ReturnsAsync(FakeData.DifferentSizeItems);

            var result = await _diffItemManager.GetResultForItemAsync(It.IsAny<int>());

            Assert.AreEqual(DiffItemManager.DIFFERENT_SIZE, result);
        }

        [TestMethod]
        public async Task EqualInputs()
        {
            _diffItemStoreMock.Setup(s => s.FindItemsById(It.IsAny<int>(), default)).ReturnsAsync(FakeData.EqualValuesItems);

            var result = await _diffItemManager.GetResultForItemAsync(It.IsAny<int>());

            Assert.AreEqual(DiffItemManager.EQUAL_INPUTS, result);
        }

        [TestMethod]
        public async Task SimpleDiff()
        {
            _diffItemStoreMock.Setup(s => s.FindItemsById(It.IsAny<int>(), default)).ReturnsAsync(FakeData.SameLengthDifferentValuesItems);

            var result = await _diffItemManager.GetResultForItemAsync(It.IsAny<int>());

            Assert.AreEqual("{[offset 8, length 18]}", result);
        }
    }
}
