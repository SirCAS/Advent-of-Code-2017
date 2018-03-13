using System.IO;
using NUnit.Framework;

namespace Day04.Tests
{
    [TestFixture]
    public class PassphraseValidatorTests
    {
        [TestCase("aa bb cc dd ee")]
        [TestCase("aa bb cc dd aaa")]
        [Test]
        public void CheckValidPassphrasesUsingLegacy(string input)
        {
            // Act
            var result = PassphraseValidator.IsValid(input, true);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("aa bb cc dd aa")]
        [Test]
        public void CheckInvalidPassphrasesUsingLegacy(string input)
        {
            // Act
            var result = PassphraseValidator.IsValid(input, true);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase("abcde fghij")]
        [TestCase("a ab abc abd abf abj")]
        [TestCase("iiii oiii ooii oooi oooo")]
        [Test]
        public void CheckValidPassphrases(string input)
        {
            // Act
            var result = PassphraseValidator.IsValid(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("abcde xyz ecdab")]
        [TestCase("oiii ioii iioi iiio")]
        [Test]
        public void CheckInvalidPassphrases(string input)
        {
            // Act
            var result = PassphraseValidator.IsValid(input);

            // Assert
            Assert.IsFalse(result);
        }
    }
}