using DataAccess;
using ClosedXML.Excel;

namespace Business
{
    public class PersonService : IPersonService
    {
        private readonly IDataAccess _data;
        public PersonService(IDataAccess data)
        {
            _data = data;
        }
        public IEnumerable<Person> GetAllMales()
        {
            return _data.GetAll().Where(p => p.Gender == Person.GenderType.Male);
        }
        public Person? GetOldest()
        {
            return _data.GetAll().MinBy(p => p.Birthday);
        }
        public IEnumerable<PersonWithFullName> GetAllWithFullname()
        {
            return _data.GetAll().Select(p => new PersonWithFullName(p));
        }
        public IEnumerable<Person> GetPersonsByYear(int year, AgeComparer comparer = AgeComparer.Equal)
        {
            var persons = _data.GetAll();
            switch (comparer)
            {
                case AgeComparer.Equal:
                    return persons.Where(p => p.Birthday.Year == year);
                case AgeComparer.Higher:
                    return persons.Where(p => p.Birthday.Year > year);
                case AgeComparer.Lower:
                    return persons.Where(p => p.Birthday.Year < year);
                default:
                    return [];
            }
        }
        public string ToExcel()
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Persons");

            worksheet.Cell(2, 2).Value = "#";
            worksheet.Cell(2, 3).Value = "First Name";
            worksheet.Cell(2, 4).Value = "Last Name";
            worksheet.Cell(2, 5).Value = "Gender";
            worksheet.Cell(2, 6).Value = "Date Of Birth";
            worksheet.Cell(2, 7).Value = "Phone Number";
            worksheet.Cell(2, 8).Value = "Birth Place";
            worksheet.Cell(2, 9).Value = "Is Graduated";

            var count = 1;
            foreach (var i in _data.GetAll())
            {
                worksheet.Cell(count + 2, 2).Value = count;
                worksheet.Cell(count + 2, 3).Value = i.FirstName;
                worksheet.Cell(count + 2, 4).Value = i.LastName;
                worksheet.Cell(count + 2, 5).Value = i.Gender.ToString();
                worksheet.Cell(count + 2, 6).Value = $"{i.Birthday}";
                worksheet.Cell(count + 2, 7).Value = i.PhoneNumber;
                worksheet.Cell(count + 2, 8).Value = i.BirthPlace;
                worksheet.Cell(count + 2, 9).Value = i.IsGraduated ? "Yes" : "No";
                count++;
            }

            string filename = $"Persons.xlsx";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            workbook.SaveAs(filePath);

            return filePath;

        }
        public class PersonWithFullName : Person
        {
            public string FullName { get; set; }
            public PersonWithFullName(Person person)
            {
                FirstName = person.FirstName;
                LastName = person.LastName;
                Birthday = person.Birthday;
                BirthPlace = person.BirthPlace;
                IsGraduated = person.IsGraduated;
                Gender = person.Gender;
                FullName = $"{FirstName} {LastName}";
            }
        }
    }
}
