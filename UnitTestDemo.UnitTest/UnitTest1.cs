using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDemo.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void n이_1이면_1이_반환되어야_함()
        {
            int result = Program.Fib(1);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void n이_2이면_2가_반환되어야_함()
        {
            int result = Program.Fib(2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void n이_3보다_크면_이전_두_수열의_합을_반환()
        {
            int result = Program.Fib(3);

            Assert.AreEqual(Program.Fib(1) + Program.Fib(2), result);
        }

    }
}
