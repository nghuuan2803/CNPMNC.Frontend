namespace AdminUI.Objects
{
    public class WarehouseModel
    {
        public string Id { get; set; }
        //[StringLength(100)]
        public string Name { get; set; }

        //[StringLength(150)]
        public string Address { get; set; }

        //[StringLength(30)]
        public string Email { get; set; }

        //[StringLength(10)]
        public string PhoneNumber { get; set; }

        public int CapacityStatus { get; set; }

        public bool Discontinued { get; set; }

        //[StringLength(10)]
        public string? ManagerId { get; set; } //FK

        public string? KeeperName { get; set; }

        public WarehouseModel(string id, string name, string address, string email, string phoneNumber, int capacityStatus = 0, bool discontinued = false, string? managerId = null)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            CapacityStatus = capacityStatus;
            Discontinued = discontinued;
            ManagerId = managerId;
        }
        public WarehouseModel()
        {
        }
    }

    public class WarehouseResponse
    {
        public string Message { get; set; }
        public WarehouseModel Data { get; set; }
    }
    public class WarehouseListResponse
    {
        public string Message { get; set; }
        public List<WarehouseModel> Data { get; set; }
    }
}
