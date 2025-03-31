using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using mvc_part1.Models;
using System.Diagnostics;
using ClosedXML.Excel;

namespace mvc_part1.Controllers
{
    public class RookiesController : Controller
    {
        private readonly List<Person> _persons;

        public RookiesController(List<Person> persons)
        {
            _persons = persons;
        }

        public IActionResult Male()
        {
            return View(_persons.Where(p => p.Gender == Person.GenderType.Male));
        }

        public IActionResult Oldest()
        {
            return View(_persons.MinBy(p => p.Birthday));
        }

        public IActionResult FullName()
        {
            return View(_persons);
        }

        public IActionResult AgeFilter([FromQuery] string action)
        {
            List<Person> result;
            switch (action.ToLower())
            {
                case "over2000":
                    result = _persons.FindAll(p => p.Birthday.Year > 2000);
                    ViewData["Title"] = "Members who borned after 2000";
                    break;
                case "under2000":
                    result = _persons.FindAll(p => p.Birthday.Year < 2000);
                    ViewData["Title"] = "Members who borned before 2000";
                    break;
                case "in2000":
                    result = _persons.FindAll(p => p.Birthday.Year == 2000);
                    ViewData["Title"] = "Members who borned in 2000";
                    break;
                default:
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View(result);
        }

        public IActionResult Excel()
        {
            
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                worksheet.Cell(2, 2).Value = "#";
                worksheet.Cell(2, 3).Value = "First Name";
                worksheet.Cell(2, 4).Value = "Last Name";
                worksheet.Cell(2, 5).Value = "Gender";
                worksheet.Cell(2, 6).Value = "Date Of Birth";
                worksheet.Cell(2, 7).Value = "Phone Number";
                worksheet.Cell(2, 8).Value = "Birth Place";
                worksheet.Cell(2, 9).Value = "Is Graduated";

                
                for (var i = 0; i < _persons.Count; i++ )
                {
                    worksheet.Cell(i + 3, 2).Value = i + 1;
                    worksheet.Cell(i + 3, 3).Value = _persons[i].FirstName;
                    worksheet.Cell(i + 3, 4).Value = _persons[i].LastName;
                    worksheet.Cell(i + 3, 5).Value = _persons[i].Gender.ToString();
                    worksheet.Cell(i + 3, 6).Value = $"{_persons[i].Birthday}";
                    worksheet.Cell(i + 3, 7).Value = _persons[i].PhoneNumber;
                    worksheet.Cell(i + 3, 8).Value = _persons[i].BirthPlace;
                    worksheet.Cell(i + 3, 9).Value = _persons[i].IsGraduated ? "Yes" : "No";
                }

                string filename = $"Persons.xlsx";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
                workbook.SaveAs(filePath);

                return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }
    }
}
