using System.IO;
using NUnit.Framework;

namespace Day02.Tests
{
    [TestFixture]
    public class SpreadsheetChecksumCalculatorTests
    {
        [Test]
        public void SumTest()
        {
            string[] input = { "5\t1\t9\t5", "7\t5\t3", "2\t4\t6\t8" };
            // Act
            var sum = SpreadsheetChecksumCalculator.CheckSum(input);

            // Assert
            Assert.AreEqual(18, sum);
        }
    }
}