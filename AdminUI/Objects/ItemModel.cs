namespace AdminUI.Objects
{
    public class ItemModel
    {
        public string Id { get; set; }
        public string? BatchId { get; set; }
        public string ProductId { get; set; }
        public string? ProductName { get; set; }

        public bool Exported { get; set; }

        public string? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }

        public string? Barcode { get; set; }
        public string? QRcode { get; set; }
        public string? Rfid { get; set; }

        public string? Photo { get; set; }
    }
}
