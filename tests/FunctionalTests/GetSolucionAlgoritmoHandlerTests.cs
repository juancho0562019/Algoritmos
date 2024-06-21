
using Application.Features.Algoritmos.GetSolucion;
using Domain.Interfaces;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace FunctionalTests
{
    [TestFixture]
    public class GetSolucionAlgoritmoHandlerTests
    {
        private GetSolucionAlgoritmoHandler _handler;
        private Mock<IPatronExtraccionStrategyFactory> _factoryMock;
        private Mock<IPatronExtraccionStrategy> _strategyMock;

        [SetUp]
        public void Setup()
        {
            _factoryMock = new Mock<IPatronExtraccionStrategyFactory>();
            _strategyMock = new Mock<IPatronExtraccionStrategy>();
            _factoryMock.Setup(f => f.CreateStrategy(It.IsAny<string>())).Returns(_strategyMock.Object);

            _handler = new GetSolucionAlgoritmoHandler(_factoryMock.Object);
        }

        [Test]
        public async Task Should_Return_Response_With_Extracted_Value()
        {
            var request = new GetSolucionAlgoritmoRequest { Cadena = "12345" };
            _strategyMock.Setup(s => s.ExtraerValores(It.IsAny<string>())).Returns("3");

            var response = await _handler.Handle(request, new CancellationToken());

            Assert.That(response.Respuesta, Is.EqualTo("3"));
            _factoryMock.Verify(f => f.CreateStrategy("Centro"), Times.Once);
            _strategyMock.Verify(s => s.ExtraerValores("12345"), Times.Once);
        }

        [Test]
        public void Should_Enforce_MaxLength_Validation()
        {
            var request = new GetSolucionAlgoritmoRequest { Cadena = new string('a', 31) };

            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
            Assert.That(validationResults.Exists(v => v.ErrorMessage != null && v.ErrorMessage.Contains("Tamaño maximo de cadena 30")), Is.True);
        }

        [Test]
        public void Should_Enforce_Required_Validation()
        {
            var request = new GetSolucionAlgoritmoRequest { Cadena = null };

            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
            Assert.That(validationResults.Exists(v => v.ErrorMessage != null && v.ErrorMessage.Contains("Campo cadena requerido")), Is.True);
        }
    }
}
