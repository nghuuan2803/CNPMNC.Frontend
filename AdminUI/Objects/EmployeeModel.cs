using static Bogus.DataSets.Name;

namespace AdminUI.Objects
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        //[StringLength(15)]
        public string FirstName { get; set; }

        //[StringLength(15)]
        public string LastName { get; set; }

        public DateOnly BirthDate { get; set; }

        //[StringLength(20)]
        public string Position { get; set; }

        //[StringLength(30)]
        public string? Email { get; set; }

        //[StringLength(10)]
        public string PhoneNumber { get; set; }

        public int Gender { get; set; }

        //[StringLength(150)]
        public string? Address { get; set; }

        public DateOnly? StartDate { get; set; }

        public double Salary { get; set; }

        //[StringLength(12)]
        public string IdentityNumber { get; set; }

        public int Status { get; set; }

        public string? WarehouseId { get; set; } //FK

    }

    public class EmployeeResponse
    {
        public string Message { get; set; }
        public EmployeeModel Data { get; set; }
    }
    public class EmployeeListResponse
    {
        public string Message { get; set; }
        public List<EmployeeModel> Data { get; set; }
    }
}
