namespace DataAccess
{
    public interface IDataAccess
    {
        public IEnumerable<Person> ListAll();
        public void Create(Person item);
        public void Delete(Person item);
        public void Update(Person item);

    }
}
