using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using calculatrice;

namespace testUnitaire {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestAddition_int_() {

            int a = 3, b = 7;
            int c = Calculatrice.Addition( a, b );

            Assert.AreEqual(10,c);
        }
    }
}
