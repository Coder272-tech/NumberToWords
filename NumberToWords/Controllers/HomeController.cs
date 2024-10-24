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
        public IActionResult ConvertToWords(AmountRequest request)
        {
            try
            {
                _logger.LogInformation("ConvertToWords accessed.");
                var processor = new NumberToWordsProcessor();
                string words = processor.Convert(request.Amount);
                // Pass the result and amount back to the view using ViewData or ViewBag
                ViewData["Result"] = words;
                ViewData["Amount"] = request.Amount;

                return View("Index", request);  // Return the Index view with the request model
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error in ConvertToWords: " + ex.Message + "\r\nStackTrace: " + ex.StackTrace + "\r\nInnerException: " + ex.InnerException );
                return BadRequest(new { error = ex.Message });
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
