
using Domain.Interfaces;
using Domain.UseCases;
using Moq;

namespace FunctionalTests
{
    [TestFixture]
    public class PatronExtraccionStrategyFactoryTests
    {
        private PatronExtraccionStrategyFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new PatronExtraccionStrategyFactory();
        }

        [Test]
        public void Should_Register_And_Create_Strategy_Successfully()
        {
            var mockStrategy = new Mock<IPatronExtraccionStrategy>();
            _factory.RegisterStrategy("mock", mockStrategy.Object);

            var result = _factory.CreateStrategy("mock");

            Assert.That(result, Is.EqualTo(mockStrategy.Object));
        }

        [Test]
        public void Should_Throw_Exception_When_Strategy_Not_Found()
        {
            Assert.Throws<ArgumentException>(() => _factory.CreateStrategy("nonexistent"));
        }
    }
}
