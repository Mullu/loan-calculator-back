using LoanCalculator.Models;

namespace LoanCalculator.Services.Calculator
{
    public interface ILoanCalculatorService
    {
        decimal CalculateInterestRate(Loan loan);
        List<PaymentPlan> CalculatePaymentPlan(Loan loan);
    }
}
