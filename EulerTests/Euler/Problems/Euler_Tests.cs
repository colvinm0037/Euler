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
            string expected = Answers.Problem_001;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_002_Test()
        {
            Euler_002 euler = new Euler_002();
            string expected = Answers.Problem_002;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_003_Test()
        {
            Euler_003 euler = new Euler_003();
            string expected = Answers.Problem_003;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_004_Test()
        {
            Euler_004 euler = new Euler_004();
            string expected = Answers.Problem_004;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_005_Test()
        {
            Euler_005 euler = new Euler_005();
            string expected = Answers.Problem_005;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_006_Test()
        {
            Euler_006 euler = new Euler_006();
            string expected = Answers.Problem_006;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_007_Test()
        {
            Euler_007 euler = new Euler_007();
            string expected = Answers.Problem_007;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_008_Test()
        {
            Euler_008 euler = new Euler_008();
            string expected = Answers.Problem_008;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_009_Test()
        {
            Euler_009 euler = new Euler_009();
            string expected = Answers.Problem_009;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_010_Test()
        {
            Euler_010 euler = new Euler_010();
            string expected = Answers.Problem_010;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_011_Test()
        {
            Euler_011 euler = new Euler_011();
            string expected = Answers.Problem_011;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_012_Test()
        {
            Euler_012 euler = new Euler_012();
            string expected = Answers.Problem_012;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_013_Test()
        {
            Euler_013 euler = new Euler_013();
            string expected = Answers.Problem_013;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_014_Test()
        {
            Euler_014 euler = new Euler_014();
            string expected = Answers.Problem_014;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Problem_015_Test()
        {
            Euler_015 euler = new Euler_015();
            string expected = Answers.Problem_015;
            string result = euler.Run();
            Assert.AreEqual(expected, result);
        }
    }
}