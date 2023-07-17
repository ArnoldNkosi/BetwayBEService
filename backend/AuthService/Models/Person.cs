namespace AuthService.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string surname { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
    }
}
