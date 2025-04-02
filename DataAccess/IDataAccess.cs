using Model;

namespace DataAccess
{
    public interface IDataAccess
    {
        public IEnumerable<ResponsePerson> ListAll();
        public ResponsePerson Create(RequestPerson person);
        public bool Delete(string id);
        public bool Update(RequestPerson person);
    }
}
