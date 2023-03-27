using Microsoft.AspNetCore.Mvc;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzzForm FizzBuzz { set; get; }
        [BindProperty(SupportsGet = true)]
        public string Name { set; get; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }

        }
        public IActionResult OnPost()
        {


            if (FizzBuzz.Number % 3 == 0 && FizzBuzz.Number % 5 == 0)
            {
                ViewData["Message"] = "FizzBuzz";
                FizzBuzz.MessageCssClass = "bg-success";
            }
            else if (FizzBuzz.Number % 3 == 0)
            {
                ViewData["Message"] = "Fizz";
                FizzBuzz.MessageCssClass = "bg-success";
            }
            else if (FizzBuzz.Number % 5 == 0)
            {
                ViewData["Message"] = "Buzz";
                FizzBuzz.MessageCssClass = "bg-success";
            }
            else
            {
                ViewData["Message"] = $"Liczba: {FizzBuzz.Number} nie spełnia kryteriów FizzBuzz";
                FizzBuzz.MessageCssClass = "bg-success";
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }
    }
}