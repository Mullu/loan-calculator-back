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

        private bool IsValidAmount(object amount)
        {
            return amount is decimal decimalAmount &&
                   decimalAmount > MinLoanAmount &&
                   decimalAmount <= MaxDecimalValue;
        }

        private bool IsValidDuration(object duration)
        {
            return duration is int intDuration &&
                   intDuration > MinLoanDurationInYears &&
                   intDuration <= MaxIntValue;
        }
    }
}
