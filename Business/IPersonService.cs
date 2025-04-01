using static Business.PersonService;

namespace Business
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetAllMales();
        public Person? GetOldest();
        public IEnumerable<PersonWithFullName> GetAllWithFullname();
        public string ToExcel();
        public IEnumerable<Person> GetPersonsByYear(int year, AgeComparer comparer = AgeComparer.Equal);
    }
}
