using LoanCalculator.Models;
using LoanCalculator.Services.InputRequestValidator;
using Xunit;

namespace LoanCalculator.Tests.Services.InputRequestValidator
{
    public class InputRequestValidatorServiceTests
    {
        [Theory]
        [InlineData(10000, 5, true, null)]
        [InlineData(0, 5, false, "Invalid loan amount.")]
        [InlineData(10000, 0, false, "Invalid loan duration.")]
        public void LoanInputValidation_ValidatesInputCorrectly(
            decimal amount,
            int durationInYears,
            bool expectedIsValid,
            string expectedErrorMessage)
        {
            // Arrange
            var loan = new Loan
            {
                Amount = amount,
                DurationInYears = durationInYears
            };

            var validator = new InputRequestValidatorService();

            // Act
            var (isValid, errorMessage) = validator.LoanInputValidation(loan);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
            Assert.Equal(expectedErrorMessage, errorMessage);
        }
    }
}
