using LoanCalculator.Models;

namespace LoanCalculator.Services.InputRequestValidator
{
    public interface IInputRequestValidatorService
    {
        public (bool isLoanInputValid, string? errorMessage) LoanInputValidation(Loan loan);
    }
}
