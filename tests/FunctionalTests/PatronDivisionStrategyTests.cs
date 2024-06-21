using Domain.Exceptions;
using Domain.UseCases;

namespace FunctionalTests
{
    [TestFixture]
    public class PatronDivisionStrategyTests
    {
        private PatronDivisionStrategy _strategy;

        [SetUp]
        public void Setup()
        {
            _strategy = new PatronDivisionStrategy();
        }

        [Test]
        public void Should_Throw_InvalidStringException_When_Input_Is_Null()
        {
            Assert.Throws<InvalidStringException>(() => _strategy.ExtraerValores(null));
        }

        [Test]
        public void Should_Throw_InvalidStringException_When_Input_Is_Empty()
        {
            Assert.Throws<InvalidStringException>(() => _strategy.ExtraerValores(string.Empty));
        }

        [TestCase("1234", ExpectedResult = "23")]
        [TestCase("abcde", ExpectedResult = "c")]
        [TestCase("a", ExpectedResult = "a")]
        public string Should_Correctly_Extract_Values(string input)
        {
            return _strategy.ExtraerValores(input);
        }
    }
}