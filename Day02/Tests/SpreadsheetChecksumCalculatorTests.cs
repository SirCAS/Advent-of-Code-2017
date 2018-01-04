using System.IO;
using NUnit.Framework;

namespace Day02.Tests
{
    [TestFixture]
    public class SpreadsheetChecksumCalculatorTests
    {
        [Test]
        public void CheckSumTest()
        {
            string[] input = { "5\t1\t9\t5", "7\t5\t3", "2\t4\t6\t8" };
            // Act
            var sum = SpreadsheetChecksumCalculator.CheckSum(input);

            // Assert
            Assert.AreEqual(18, sum);
        }

        [Test]
        public void SumTest()
        {
            string[] input = { "5\t9\t2\t8", "9\t4\t7\t3", "3\t8\t6\t5" };
            
            // Act
            var sum = SpreadsheetChecksumCalculator.Sum(input);

            // Assert
            Assert.AreEqual(9, sum);
        }
    }
}