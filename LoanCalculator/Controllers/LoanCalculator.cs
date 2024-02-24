using LoanCalculator.Models;
using LoanCalculator.Services.Calculator;
using LoanCalculator.Services.InputRequestValidator;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.Controllers
{
    /// <summary>
    /// Controller for managing loans.
    /// </summary>
    [ApiController]
    [Route("controller/api/v1")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanCalculatorService _calculator;
        private readonly ILogger<LoanController> _logger;
        private readonly IInputRequestValidatorService _inputRequestValidatorService;

        public LoanController(
            ILoanCalculatorService calculator,
            ILogger<LoanController> logger,
            IInputRequestValidatorService inputRequestValidatorService)
        {
            _calculator = calculator;
            _logger = logger;
            _inputRequestValidatorService = inputRequestValidatorService;
        }

        /// <summary>
        /// Calculates the payment plan for a loan.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET /loan/calculate?amount=10000&durationInYears=5
        /// </remarks>
        /// <param name="loan">The loan details.</param>
        /// <returns>The payment plan for the loan.</returns>
        [HttpGet("CalculateLoan")]
        [ProducesResponseType(typeof(List<PaymentPlan>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult CalculateLoan([FromQuery] Loan loan)
        {
            var (isLoanInputValid, errorMessage) =
                _inputRequestValidatorService.LoanInputValidation(loan);

            if (!isLoanInputValid && !string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            try
            {
                var paymentPlan = _calculator.CalculatePaymentPlan(loan);
                return Ok(paymentPlan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request");
                return StatusCode(500);
            }
        }
    }
}
