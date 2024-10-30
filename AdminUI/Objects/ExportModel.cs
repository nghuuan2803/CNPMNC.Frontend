namespace AdminUI.Objects
{
    public class ExportModel
    {
        public int Id { get; set; }

        public string? InvoiceId { get; set; }

        public double Amount { get; set; }

        public ExportStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ExportDate { get; set; }

        //[StringLength(200)]
        public string? Note { get; set; }

        public DateTime? PaidDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int AgencyId { get; set; }

        public string OrderBy { get; set; }

        public string AgencyName { get; set; }

        //[StringLength(10)]
        public string? ManagerId { get; set; }

        public string? ManagerName { get; set; }

        public ICollection<ExportItem> Items { get; set; }
    }
    public class ExportItem
    {
        public int Id { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ExportId { get; set; }

        public string ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Photo { get; set; }

        //[StringLength(5)]
        public string WarehouseId { get; set; }

        public string? WarehouseName { get; set; }
    }

    public class ExportListResponse
    {
        public string? Message { get; set; }
        public List<ExportModel> Data { get; set; }
    }
    public class ExportResponse
    {
        public string? Message { get; set; }
        public ExportModel Data { get; set; }
    }
    public class SelectExportItem
    {
        public int Id { get; set; }

        public string ImportId { get; set; }
        public string ProductId { get; set; }

        public string Name { get; set; }

        public double ExportPrice { get; set; }

        public int ExportQty { get; set; }

        public string? Photo { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }
    }
    public enum ExportStatus
    {
        Pending,
        OrderCanceled,
        OrderRefuse,
        InProgress,
        Completed,
        Canceled
    }
}
