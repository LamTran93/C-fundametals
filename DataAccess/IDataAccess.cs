using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess
    {
        public IEnumerable<Person> GetAll();
        public void Add(Person item);
        public void Remove(Person item);
    }
}
