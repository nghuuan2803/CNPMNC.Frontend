namespace AdminUI.Objects
{
    public class ImportModel
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public double Amount { get; set; }

        //[StringLength(200)]
        public string? Note { get; set; }

        //[StringLength(10)]
        public string OrderBy { get; set; }

        public int SuplierId { get; set; }

        //[StringLength(5)]
        public string WarehouseId { get; set; }


        public string? SuplierName { get; set; }
        public string? WarehouseName { get; set; }
        public string? ManagerName { get; set; }

        public ICollection<ImportItem>? Items { get; set; }

        public string? InvoiceImage { get; set; }

        public bool CheckPassed { get; set; } = true;

        public DateTime? PaidDate { get; set; }
    }
    public class ImportItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public string ImportId { get; set; }
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Photo { get; set; }
    }

    public class ImportListResponse
    {
        public string? Message { get; set; }
        public List<ImportModel> Data { get; set; }
    }
    public class ImportResponse
    {
        public string? Message { get; set; }
        public ImportModel Data { get; set; }
    }
}
