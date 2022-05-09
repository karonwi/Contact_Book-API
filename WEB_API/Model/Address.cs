namespace API.Model
{
    public class Address
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string  City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
