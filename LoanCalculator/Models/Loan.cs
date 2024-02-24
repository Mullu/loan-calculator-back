
namespace LoanCalculator.Models
{
    public class Loan
    {
        public decimal Amount { get; set; }

        public int DurationInYears { get; set; }

        public decimal InterestRate { get; set; } = 3.5m;

        public LoanType LoanType { get; set; } = LoanType.Housing;
    }
}
