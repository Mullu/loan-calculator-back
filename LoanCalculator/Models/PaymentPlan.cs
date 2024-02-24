
namespace LoanCalculator.Models
{
    public class PaymentPlan
    {
        public int Month { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal RemainingAmount { get; set; }
    }
}
