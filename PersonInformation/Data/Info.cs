namespace PersonInformation.Data
{
    public class Info
    {
        public int id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string imgURL { get; set; }
        public int Age { get; set; }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }


    }
}
