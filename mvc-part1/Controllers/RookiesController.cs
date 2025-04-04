﻿using Microsoft.AspNetCore.Mvc;
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
            return View(_service.GetAll());
        }

        public IActionResult FullList()
        {
            return View("Persons", _service.GetAll());
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
            return Ok(persons);
        }

        public IActionResult Higher([FromQuery] int year)
        {
            var persons = _service.GetPersonsByYear(year, AgeComparer.Higher);
            return Ok(persons);
        }

        public IActionResult Lower([FromQuery] int year)
        {
            var persons = _service.GetPersonsByYear(year, AgeComparer.Lower);
            return Ok(persons);
        }

        public IActionResult Excel()
        {
            try
            {
                var excelStream = _service.ToExcel();

                return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "persons.xlsx");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
