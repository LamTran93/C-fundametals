using Model;
using static Business.PersonService;

namespace Business
{
    public interface IPersonService
    {
        public IEnumerable<ResponsePerson> GetAllMales();
        public ResponsePerson? GetOldest();
        public IEnumerable<ResponsePerson> GetAll();
        public Stream ToExcel();
        public IEnumerable<ResponsePerson> GetPersonsByYear(int year, AgeComparer comparer = AgeComparer.Equal);
    }
}
