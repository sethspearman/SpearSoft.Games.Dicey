using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           //a a a arrange, act, assert

            var r = new Random();

            int val = r.Next(1, 1);

            //Assert.That(val==1)



        }
    }
}
