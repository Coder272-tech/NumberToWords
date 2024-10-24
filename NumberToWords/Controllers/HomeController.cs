using Microsoft.AspNetCore.Mvc;
using NumberToWordsLib;

namespace NumberToWordsSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Home page accessed.");
            return View();
        }

        [HttpPost]
        public IActionResult ConvertToWords([FromBody] AmountRequest request)
        {
            try
            {
                _logger.LogInformation("ConvertToWords accessed.");
                var processor = new NumberToWordsProcessor();
                string words = processor.Convert(request.Amount);
                return Json(new { words });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error in ConvertToWords: " + ex.Message + "\r\nStackTrace: " + ex.StackTrace + "\r\nInnerException: " + ex.InnerException );
                return BadRequest(new { error = "Invalid input provided." });
            }
        }

        public class AmountRequest
        {
            public decimal Amount { get; set; }
        }

        public IActionResult Error()
        {
            _logger.LogError("An error occurred.");
            return View();
        }
    }
}
