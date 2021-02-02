using ConsoleAppRunner;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class FunctionTests
    {        

        [Test]
        public void CheckIsValidWord()
        {
            // Setup
            string word = "hello";

            // Invoke
            bool result = StringHelper.IsValidWord(word);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIsInvalidWord()
        {
            // Setup
            string word = "hello123";

            // Invoke
            bool result = StringHelper.IsValidWord(word);

            // Assert
            Assert.IsFalse(result);
        }

    }
}
