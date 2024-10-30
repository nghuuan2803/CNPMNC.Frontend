namespace AdminUI.Objects
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public string WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
