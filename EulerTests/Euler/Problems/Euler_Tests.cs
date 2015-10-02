using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler.Euler;

namespace Euler.Tests
{
    [TestClass()]
    public class Euler_Tests
    {
        [TestMethod()]
        public void Problem_001_Test()
        {
            Euler_001 euler = new Euler_001();
            string expected = Answers.Probelm_001;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_002_Test()
        {
            Euler_002 euler = new Euler_002();
            string expected = Answers.Probelm_002;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_003_Test()
        {
            Euler_003 euler = new Euler_003();
            string expected = Answers.Probelm_003;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_004_Test()
        {
            Euler_004 euler = new Euler_004();
            string expected = Answers.Probelm_004;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_005_Test()
        {
            Euler_005 euler = new Euler_005();
            string expected = Answers.Probelm_005;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }
    }
}