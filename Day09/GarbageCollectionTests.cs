using NUnit.Framework;

namespace Day09
{
    [TestFixture]
    public class GarbageCollectionTests
    {
        [TestCase("<>", true)]
        [TestCase("<>>", false)]
        [TestCase("<>a", false)]
        [TestCase("<!>!>>a", false)]
        [TestCase("<random characters>", true)]
        [TestCase("<<<<>", true)]
        [TestCase("<{!>}>", true)]
        [TestCase("<!!>", true)]
        [TestCase("<!!!>>", true)]
        [TestCase("<{o\"i!a,<{i<a>", true)]
        public void IsSelfcontainedTest(string input, bool expectedResult)
        {
            // Act
            var result = GarbageCollector.IsSelfcontained(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("<>", "")]
        [TestCase("<><><>", "")]
        [TestCase("{}", "{}")]
        [TestCase("{{{}}}", "{{{}}}")]
        [TestCase("{{},{}}", "{{},{}}")]
        [TestCase("{{{},{},{{}}}}", "{{{},{},{{}}}}")]
        [TestCase("{<{},{},{{}}>}", "{}")]
        [TestCase("{<a>,<a>,<a>,<a>}", "{}")]
        [TestCase("{{<a>},{<a>},{<a>},{<a>}}", "{{},{},{},{}}")]
        [TestCase("{{<!>},{<!>},{<!>},{<a>}}", "{{}}")]
        public void RemoveGarbageTest(string input, string output)
        {
            var result = GarbageCollector.RemoveGarbage(input);

            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 6)]
        [TestCase("{{},{}}", 5)]
        [TestCase("{{{},{},{{}}}}", 16)]
        public void GroupScoreTest(string input, int score)
        {
            var result = GarbageCollector.GroupScore(input);

            Assert.That(result, Is.EqualTo(score));
        }

        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void GetScoreTest(string input, int score)
        {
            var result = GarbageCollector.GetScore(input);

            Assert.That(result, Is.EqualTo(score));
        }

        [TestCase("<>", 0)]
        [TestCase("<random characters>", 17)]
        [TestCase("<<<<>", 3)]
        [TestCase("<{!>}>", 2)]
        [TestCase("<!!>", 0)]
        [TestCase("<!!!>>", 0)]
        [TestCase("<{o\"i!a,<{i<a>", 10)]
        public void RemovedGarbageTest(string input, int removed)
        {
            var result = GarbageCollector.RemovedGarbage(input);

            Assert.That(result, Is.EqualTo(removed));
        }
    }
}
