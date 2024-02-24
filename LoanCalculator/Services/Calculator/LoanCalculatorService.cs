using LoanCalculator.Models;

namespace LoanCalculator.Services.Calculator
{
    public class LoanCalculatorService : ILoanCalculatorService
    {
        private const decimal HousingInterestRate = 3.5m;
        private const int DecimalPlaces = 2;
        private const int MonthsInYear = 12;

        public decimal CalculateInterestRate(Loan loan)
        {
            switch (loan.LoanType)
            {
                case LoanType.Housing:
                    return HousingInterestRate;
                default:
                    throw new ArgumentException("Invalid loan type");
            }
        }

        public List<PaymentPlan> CalculatePaymentPlan(Loan loan)
        {
            var plan = new List<PaymentPlan>();
            var remainingAmount = loan.Amount;
            var interstRate = loan.InterestRate;
            var durationInYears = loan.DurationInYears;
            var monthlyInterestRate = CalculateMonthlyInterestRate(interstRate);
            var totalMonths = CalculateTotalMonths(durationInYears);
            var monthlyPayment = CalculateMonthlyPayment(remainingAmount, monthlyInterestRate, totalMonths);

            for (int month = 1; month <= totalMonths; month++)
            {
                decimal interestPayment = remainingAmount * monthlyInterestRate;
                decimal principalPayment = monthlyPayment - interestPayment;
                remainingAmount -= principalPayment;

                if (month == totalMonths && remainingAmount > 0)
                {
                    monthlyPayment += remainingAmount;
                    remainingAmount = 0;
                }

                decimal roundedRemainingAmount = Math.Round(remainingAmount, DecimalPlaces);
                decimal roundedMonthlyPayment = Math.Round(monthlyPayment, DecimalPlaces);

                plan.Add(new PaymentPlan
                {
                    Month = month,
                    MonthlyPayment = roundedMonthlyPayment,
                    RemainingAmount = roundedRemainingAmount
                });
            }

            return plan;
        }

        private decimal CalculateMonthlyPayment(
            decimal loanAmount,
            decimal monthlyInterestRate,
            int totalMonths)
        {
            decimal denominator = (decimal)Math.Pow((double)(1 + monthlyInterestRate), -totalMonths);
            decimal monthlyPayment = loanAmount * (monthlyInterestRate / (1 - denominator));

            return monthlyPayment;
        }

        private decimal CalculateMonthlyInterestRate(decimal annualInterestRate)
        {
            return annualInterestRate / MonthsInYear / 100;
        }

        private int CalculateTotalMonths(int years)
        {
            return years * MonthsInYear;
        }
    }
}
