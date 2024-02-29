using LoanCalculator.Models;

namespace LoanCalculator.Services.InputRequestValidator
{
    public class InputRequestValidatorService : IInputRequestValidatorService
    {
        private const decimal MinLoanAmount = 0m;
        private const int MinLoanDurationInYears = 0;
        private const decimal MaxDecimalValue = decimal.MaxValue;
        private const int MaxIntValue = int.MaxValue;

        public (bool isLoanInputValid, string? errorMessage) LoanInputValidation(Loan loan)
        {
            if (loan is null)
                return (false, "Loan object is null.");

            if (!IsValidAmount(loan.Amount))
                return (false, "Invalid loan amount.");

            if (!IsValidDuration(loan.DurationInYears))
                return (false, "Invalid loan duration.");

            return (true, null);
        }

        private bool IsValidAmount(decimal amount)
        {
            return amount > MinLoanAmount && amount <= MaxDecimalValue;
        }

        private bool IsValidDuration(int duration)
        {
            return duration > MinLoanDurationInYears && duration <= MaxIntValue;
        }
    }
}
