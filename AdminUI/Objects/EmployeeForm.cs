namespace AdminUI.Objects
{
    public class EmployeeForm
    {
        public string Id { get; set; }
        //[StringLength(15)]
        public string FirstName { get; set; }

        //[StringLength(15)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        //[StringLength(20)]
        public string Position { get; set; }

        //[StringLength(30)]
        public string? Email { get; set; }

        //[StringLength(10)]
        public string PhoneNumber { get; set; }

        public int Gender { get; set; }

        //[StringLength(150)]
        public string? Address { get; set; }

        public DateTime? StartDate { get; set; }

        public double Salary { get; set; }

        //[StringLength(12)]
        public string IdentityNumber { get; set; }

        public int Status { get; set; }

        public string? WarehouseId { get; set; } //FK
    }
}
