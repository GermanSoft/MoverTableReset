using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoverReset;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Initialization()
        {
            MoverTable moverTable = new MoverTable(10,1000);

            Assert.AreEqual(10,moverTable.MoverList.Count);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, moverTable.MoverList[i].Id);
            }
        }

        [TestMethod]
        public void Test_Mover1Shifted()
        {
            MoverTable moverTable = new MoverTable(10, 1000);
            
            moverTable.Move(0,-20);

            Assert.AreEqual(true,moverTable.CanMove(0));

            for (int i = 1; i < 10; i++)
            {
                Assert.AreEqual(false, moverTable.CanMove(i));

            }
        }

        [TestMethod]
        public void Test_Mover1and2Shifted()
        {
            MoverTable moverTable = new MoverTable(10, 1000);

            moverTable.Move(0, -200);
            moverTable.Move(1, -100);

            Assert.AreEqual(false, moverTable.CanMove(0));
            Assert.AreEqual(true, moverTable.CanMove(1));

            for (int i = 2; i < 10; i++)
            {
                Assert.AreEqual(false, moverTable.CanMove(i));

            }
        }
    }
}
