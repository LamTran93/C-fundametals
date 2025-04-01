using Microsoft.AspNetCore.Mvc;
using mvc_part1.Models;
using System.Diagnostics;
using Business;

namespace mvc_part1.Controllers
{
    public class RookiesController : Controller
    {
        private readonly IPersonService _service;

        public RookiesController(IPersonService service)
        {
            _service = service;
        }

        public IActionResult Male()
        {
            return View("Persons", _service.GetAllMales());
        }

        public IActionResult Oldest()
        {
            return View(_service.GetOldest());
        }

        public IActionResult FullName()
        {
            return View(_service.GetAllWithFullname());
        }

        public IActionResult AgeFilter([FromQuery] string year, [FromQuery] string compare)
        {
            if (!int.TryParse(year, out int result)) return RedirectToAction("Error", "Home");

            switch (compare)
            {
                case "equal":
                    return RedirectToAction("Equal", new { year = result });
                case "higher":
                    return RedirectToAction("Higher", new { year = result });
                case "lower":
                    return RedirectToAction("Lower", new { year = result });
                default:
                    return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Equal([FromQuery] int year)
        {
            var persons = _service.GetPersonsByYear(year);
            return View("Persons", persons);
        }

        public IActionResult Higher([FromQuery] int year)
        {
            var persons = _service.GetPersonsByYear(year, AgeComparer.Higher);
            return View("Persons", persons);
        }

        public IActionResult Lower([FromQuery] int year)
        {
            var persons = _service.GetPersonsByYear(year, AgeComparer.Lower);
            return View("Persons", persons);
        }

        public IActionResult Excel()
        {
            try
            {
                var filePath = _service.ToExcel();

                return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
