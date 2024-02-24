using LoanCalculator.Controllers;
using LoanCalculator.Models;
using LoanCalculator.Services.Calculator;
using LoanCalculator.Services.InputRequestValidator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LoanCalculator.Tests.Controllers
{
    public class LoanControllerTests
    {
        private Mock<ILoanCalculatorService> _calculatorMock;
        private Mock<ILogger<LoanController>> _loggerMock;
        private Mock<IInputRequestValidatorService> _validatorMock;
        private LoanController _controller;

        public LoanControllerTests()
        {

            _calculatorMock = new Mock<ILoanCalculatorService>();
            _loggerMock = new Mock<ILogger<LoanController>>();
            _validatorMock = new Mock<IInputRequestValidatorService>();
            _controller = new LoanController(_calculatorMock.Object, _loggerMock.Object, _validatorMock.Object);
        }

        [Fact]
        public void CalculateLoan_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var loan = new Loan
            {
                Amount = 10000,
                DurationInYears = 5,
                InterestRate = 3.5m,
                LoanType = LoanType.Housing
            };

            _calculatorMock.Setup(x => x.CalculatePaymentPlan(It.IsAny<Loan>()))
                           .Returns(new List<PaymentPlan>());

            _validatorMock.Setup(x => x.LoanInputValidation(It.IsAny<Loan>()))
                          .Returns((true, null));

            // Act
            var result = _controller.CalculateLoan(loan);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CalculateLoan_InvalidInput_ReturnsBadRequest()
        {
            // Arrange
            var loan = new Loan();

            _validatorMock.Setup(x => x.LoanInputValidation(It.IsAny<Loan>()))
                          .Returns((false, "Invalid input"));

            // Act
            var result = _controller.CalculateLoan(loan);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid input", badRequestResult.Value);
        }
    }
}
