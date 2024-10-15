using Microsoft.AspNetCore.Mvc;

namespace NumberToWordsSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConvertToWords([FromBody] AmountRequest request)
        {
            try
            {
                var words = NumberToWordsLib.NumberToWords.ConvertAmountToWords(request.Amount);
                return Json(new { words });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        public class AmountRequest
        {
            public decimal Amount { get; set; }
        }
    }
}
