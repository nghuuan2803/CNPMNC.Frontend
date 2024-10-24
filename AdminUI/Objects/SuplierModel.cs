namespace AdminUI.Objects
{
    public class SuplierModel
    {
        public int Id { get; set; }
        //[StringLength(100)]
        public string Name { get; set; }

        //[StringLength(150)]
        public string Address { get; set; }

        //[StringLength(50)]
        public string Email { get; set; }

        //[StringLength(15)]
        public string PhoneNumber { get; set; }

        public bool Discontinued { get; set; }
        //[StringLength(30)]
        public string? ContactPerson { get; set; }
    }
    public class SuplierResponse
    {
        public string? Message { get; set; }
        public SuplierModel Data { get; set; }
    }
    public class SuplierListResponse
    {
        public string? Message { get; set; }
        public List<SuplierModel> Data { get; set; }
    }
}
