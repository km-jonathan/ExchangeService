using ExchangeService.Model;
using ExchangeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeServiceController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeServiceController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        // Improvements: validate request data
        // - inputCurrency and outputCurrency are valid
        // - log and return error if validation fails
        [HttpPost]
        public async Task<IActionResult> ExchangeService([FromBody] ExchangeRateRequest exchangeRateRequest)
        {
            try
            {
                var exchangeResponse = await _exchangeRateService.GetExchangeRate(exchangeRateRequest);

                return Ok(exchangeResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed Request - {ex.Message}");
            }
        }

        [HttpGet]
        [Route("HealthCheck")]
        public IActionResult HealthCheck()
        {
            return Ok("Exchange Service Ready");
        }
    }
}