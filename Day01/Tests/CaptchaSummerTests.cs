using System.IO;
using NUnit.Framework;

namespace Day01.Tests
{
    [TestFixture]
    public class CaptchaSummerTests
    {
        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        [Test]
        public void SumTest(string input, int expectedResult)
        {
            // Act
            var sum = CaptchaSummer.Sum(input);

            // Assert
            Assert.AreEqual(expectedResult, sum);
        }

        [TestCase("1212", 6)]
        [TestCase("1221", 0)]
        [TestCase("123425", 4)]
        [TestCase("123123", 12)]
        [TestCase("12131415", 4)]
        [Test]
        public void SumHalfWayTest(string input, double expectedResult)
        {
            // Act
            var sum = CaptchaSummer.SumHalfway(input);

            // Assert
            Assert.AreEqual(expectedResult, sum);
        }
    }
}