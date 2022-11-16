using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDiff.Helpers;
using System;

namespace SimpleDiffTest
{
    [TestClass]
    public class DiffHelperTest
    {
        [TestMethod]
        public void Test1()
        {
            var leftInput = "alestesthradkoloauto";
            var rightInput = "avestttvhroploloioto";

            var resultDic = DiffHelper.GetDiff(leftInput, rightInput);

            Assert.AreEqual(4, resultDic.Count, $"Except number of items 4 got {resultDic.Count}");

            Assert.AreEqual(1, resultDic[1]);
            Assert.AreEqual(3, resultDic[5]);
            Assert.AreEqual(3, resultDic[10]);
            Assert.AreEqual(2, resultDic[16]);
        }

        [TestMethod]
        public void Test2()
        {
            var leftInput = "";
            var rightInput = "";

            var resultDic = DiffHelper.GetDiff(leftInput, rightInput);

            Assert.AreEqual(0, resultDic.Count, $"Except number of items 0 got {resultDic.Count}");
        }

        [TestMethod]
        public void Test3()
        {
            var leftInput = "ABCDKKADJDASDASDLJALSd";
            var rightInput = "ABCDKKADJDASDASDLJALSd";

            var resultDic = DiffHelper.GetDiff(leftInput, rightInput);

            Assert.AreEqual(0, resultDic.Count, $"Except number of items 0 got {resultDic.Count}");
        }

        [TestMethod]
        public void Test4()
        {
            var leftInput = "ABCDKKADJDASDASDLJALSb";
            var rightInput = "ABCDKKADJDASDASDLJALSd";

            var resultDic = DiffHelper.GetDiff(leftInput, rightInput);

            Assert.AreEqual(1, resultDic.Count, $"Except number of items 1 got {resultDic.Count}");
            Assert.AreEqual(1, resultDic[21]);
        }

        [TestMethod]
        public void Test5()
        {
            var leftInput = "ABCDKKADJDASDASDLJALAg";
            var rightInput = "ABCDKKADJDASDASDLJALBd";

            var resultDic = DiffHelper.GetDiff(leftInput, rightInput);

            Assert.AreEqual(1, resultDic.Count, $"Except number of items 1 got {resultDic.Count}");
            Assert.AreEqual(2, resultDic[20]);

        }

        [TestMethod]
        public void Test6()
        {
            var leftInput = "ABCDKKADJDASDASDLJALAg";
            var rightInput = "ASDDASD";

            Assert.ThrowsException<ApplicationException>(() => DiffHelper.GetDiff(leftInput, rightInput));
        }
    }
}