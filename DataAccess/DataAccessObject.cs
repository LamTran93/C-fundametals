namespace DataAccess
{
    public class DataAccessObject : IDataAccess
    {
        private static List<Person> _values;
        public DataAccessObject()
        {
            _values = [
                new Person() { FirstName = "Linh", LastName = "Nguyen", Birthday = new DateOnly(1995, 7, 15), Gender = Person.GenderType.Female, BirthPlace = "Ho Chi Minh", IsGraduated = false, PhoneNumber = "0231231743" },
                new Person() { FirstName = "Huy", LastName = "Pham", Birthday = new DateOnly(1990, 1, 10), Gender = Person.GenderType.Male, BirthPlace = "Da Nang", IsGraduated = true, PhoneNumber = "0231231744" },
                new Person() { FirstName = "Mai", LastName = "Le", Birthday = new DateOnly(1992, 12, 5), Gender = Person.GenderType.Female, BirthPlace = "Can Tho", IsGraduated = false, PhoneNumber = "0231231745" },
                new Person() { FirstName = "Tuan", LastName = "Hoang", Birthday = new DateOnly(2000, 6, 30), Gender = Person.GenderType.Male, BirthPlace = "Hai Phong", IsGraduated = true, PhoneNumber = "0231231746" },
                new Person() { FirstName = "Anh", LastName = "Vu", Birthday = new DateOnly(1991, 11, 20), Gender = Person.GenderType.Female, BirthPlace = "Hue", IsGraduated = true, PhoneNumber = "0231231747" },
                new Person() { FirstName = "Bao", LastName = "Tran", Birthday = new DateOnly(1994, 4, 18), Gender = Person.GenderType.Male, BirthPlace = "Nha Trang", IsGraduated = false, PhoneNumber = "0231231748" },
                new Person() { FirstName = "Chi", LastName = "Nguyen", Birthday = new DateOnly(1996, 8, 25), Gender = Person.GenderType.Female, BirthPlace = "Quang Ninh", IsGraduated = true, PhoneNumber = "0231231749" },
                new Person() { FirstName = "Duc", LastName = "Pham", Birthday = new DateOnly(1989, 2, 14), Gender = Person.GenderType.Male, BirthPlace = "Binh Dinh", IsGraduated = true, PhoneNumber = "0231231750" },
                new Person() { FirstName = "Em", LastName = "Le", Birthday = new DateOnly(1997, 5, 30), Gender = Person.GenderType.Female, BirthPlace = "Vung Tau", IsGraduated = false, PhoneNumber = "0231231751" },
                new Person() { FirstName = "Phuc", LastName = "Hoang", Birthday = new DateOnly(1992, 9, 12), Gender = Person.GenderType.Male, BirthPlace = "Dong Nai", IsGraduated = true, PhoneNumber = "0231231752" },
                new Person() { FirstName = "Giang", LastName = "Vu", Birthday = new DateOnly(1993, 3, 22), Gender = Person.GenderType.Female, BirthPlace = "Ha Noi", IsGraduated = true, PhoneNumber = "0231231753" },
                new Person() { FirstName = "Hanh", LastName = "Tran", Birthday = new DateOnly(1995, 7, 15), Gender = Person.GenderType.Male, BirthPlace = "Ho Chi Minh", IsGraduated = false, PhoneNumber = "0231231754" },
                new Person() { FirstName = "Khanh", LastName = "Nguyen", Birthday = new DateOnly(1990, 1, 10), Gender = Person.GenderType.Female, BirthPlace = "Da Nang", IsGraduated = true, PhoneNumber = "0231231755" },
                new Person() { FirstName = "Loi", LastName = "Pham", Birthday = new DateOnly(2004, 12, 5), Gender = Person.GenderType.Male, BirthPlace = "Can Tho", IsGraduated = false, PhoneNumber = "0231231756" },
                new Person() { FirstName = "Minh", LastName = "Le", Birthday = new DateOnly(1988, 6, 30), Gender = Person.GenderType.Female, BirthPlace = "Hai Phong", IsGraduated = true, PhoneNumber = "0231231757" },
                new Person() { FirstName = "Nghia", LastName = "Hoang", Birthday = new DateOnly(1991, 11, 20), Gender = Person.GenderType.Male, BirthPlace = "Hue", IsGraduated = true, PhoneNumber = "0231231758" },
                new Person() { FirstName = "Oanh", LastName = "Vu", Birthday = new DateOnly(2005, 4, 18), Gender = Person.GenderType.Female, BirthPlace = "Nha Trang", IsGraduated = false, PhoneNumber = "0231231759" },
                new Person() { FirstName = "Phuong", LastName = "Tran", Birthday = new DateOnly(1996, 8, 25), Gender = Person.GenderType.Male, BirthPlace = "Quang Ninh", IsGraduated = true, PhoneNumber = "0231231760" },
                new Person() { FirstName = "Quyen", LastName = "Nguyen", Birthday = new DateOnly(2000, 2, 14), Gender = Person.GenderType.Female, BirthPlace = "Binh Dinh", IsGraduated = true, PhoneNumber = "0231231761" }
            ];
        }

        public IEnumerable<Person> ListAll()
        {
            return _values;
        }

        public void Create(Person person)
        {
            _values.Add(person);
        }

        public void Delete(Person person)
        {
            _values.Remove(person);
        }

        public void Update(Person person) { 
            
        }

    }
}
