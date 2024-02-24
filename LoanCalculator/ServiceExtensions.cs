using LoanCalculator.Services.Calculator;
using LoanCalculator.Services.InputRequestValidator;

namespace LoanCalculator
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ILoanCalculatorService, LoanCalculatorService>();
            services.AddScoped<IInputRequestValidatorService, InputRequestValidatorService>();

            return services;
        }
    }
}
