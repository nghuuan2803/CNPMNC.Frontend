
namespace AdminUI.Objects
{
    public class AgencyModel
    {
        public int Id { get; set; }

        //[StringLength(100)]
        public string Name { get; set; }

        //[StringLength(150)]
        public string Address { get; set; }

        //[StringLength(30)]
        public string Email { get; set; }

        //[StringLength(10)]
        public string PhoneNumber { get; set; }

        public int Type { get; set; }

        public double TotalPaid { get; set; }

        public bool Discontinued { get; set; }

        //[StringLength(20)]
        public string? ContactPerson { get; set; }
    }
    public class AgencyResponse
    {
        public string? Message { get; set; }
        public AgencyModel Data { get; set; }
    }
    public class AgencyListResponse
    {
        public string? Message { get; set; }
        public List<AgencyModel> Data { get; set; }
    }
}
