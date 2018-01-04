using System.IO;
using NUnit.Framework;

namespace Day01.Tests
{
    [TestFixture]
    public class CaptchaSummerTests
    {
        [Test]
        public void FirstMatchTest()
        {
            // 1. Arrange
            const string input = "1122";

            // 2. Act
            var sum = CaptchaSummer.Sum(input);

            // 3. Assert
            Assert.AreEqual(3, sum);
        }

        [Test]
        public void OneMatchTest()
        {
            // 1. Arrange
            const string input = "1111";

            // 2. Act
            var sum = CaptchaSummer.Sum(input);

            // 3. Assert
            Assert.AreEqual(4, sum);
        }
    
        [Test]
        public void ZeroMatchTest()
        {
            // 1. Arrange
            const string input = "1234";

            // 2. Act
            var sum = CaptchaSummer.Sum(input);

            // 3. Assert
            Assert.AreEqual(0, sum);
        }

            [Test]
        public void LastAndFirstMatchTest()
        {
            // 1. Arrange
            const string input = "91212129";

            // 2. Act
            var sum = CaptchaSummer.Sum(input);

            // 3. Assert
            Assert.AreEqual(9, sum);
        }
    }
}