namespace mvc_part1.Models
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateOnly Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
        
        public enum GenderType
        {
            Male,
            Female
        }
    }
}
