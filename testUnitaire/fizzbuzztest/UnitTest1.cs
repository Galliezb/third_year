using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSfizzbuzz;

namespace fizzbuzztest {
    [TestClass]
    public class UnitTest {
        [TestMethod]
        public void TestFizzBuzz() {

            Assert.AreEqual("fizz", FizzBuzz.GetFizzBuzz(3));
            Assert.AreEqual("fizz", FizzBuzz.GetFizzBuzz(6));
            Assert.AreEqual("fizz", FizzBuzz.GetFizzBuzz(9));

        }
    }
}
