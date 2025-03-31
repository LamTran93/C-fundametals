using Microsoft.AspNetCore.Mvc;
using mvc_part1.Models;

namespace mvc_part1.Controllers
{
    public class RookiesController : Controller
    {
        private readonly List<PersonModel> _persons;

        public RookiesController(List<PersonModel> persons)
        {
            _persons = persons;
        }

        public IActionResult Male()
        {
            return View(_persons);
        }
    }
}
