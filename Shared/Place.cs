namespace LunchFinder.Server.Places
{
    using Tags;
    
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public Address Address { get; set; }
        public List<ContactInformation>? ContactInformation { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class ContactInformation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

}

