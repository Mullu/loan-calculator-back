using LoanCalculator.Models;
using LoanCalculator.Services.Calculator;
using Xunit;

namespace LoanCalculator.Tests.Services.Calculator
{
    public class LoanCalculatorServiceTests
    {
        [Theory]
        [InlineData(3000000, 30, 3.5, LoanType.Housing, 360, 13471.34)]
        [InlineData(2000000, 20, 3.5, LoanType.Housing, 240, 11599.19)]
        public void CalculatePaymentPlan_ValidInput_ReturnsExpectedPaymentPlan(
            decimal amount,
            int durationInYears,
            decimal interestRate,
            LoanType loanType,
            int expectedInstallmentCount,
            decimal expectedMonthlyPayment)
        {
            // Arrange
            var loan = new Loan
            {
                Amount = amount,
                DurationInYears = durationInYears,
                InterestRate = interestRate,
                LoanType = loanType
            };

            var calculator = new LoanCalculatorService();

            // Act
            var paymentPlan = calculator.CalculatePaymentPlan(loan);

            // Assert
            Assert.NotNull(paymentPlan);
            Assert.Equal(expectedInstallmentCount, paymentPlan.Count);
            Assert.Equal(expectedMonthlyPayment, paymentPlan[0].MonthlyPayment);
        }
    }
}
