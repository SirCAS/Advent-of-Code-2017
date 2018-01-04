using System.IO;
using NUnit.Framework;

namespace Day03.Tests
{
    [TestFixture]
    public class SpiralMemoryTests
    {
        [TestCase(1, 0)]
        [TestCase(12, 3)]
        [TestCase(23, 2)]
        [TestCase(1024, 31)]
        [Test]
        public void GetStepsTest(int position, int stepsExpected)
        {
            // Act
            var steps = SpiralMemory.GetSteps(position);

            // Assert
            Assert.AreEqual(stepsExpected, steps);
        }
    }
}