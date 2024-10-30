namespace AdminUI.Objects.Request
{
    public class OrderRequest
    {
        public int AgencyId { get; set; }

        public string? Note { get; set; }

        //[StringLength(10)]
        public string? ManagerId { get; set; }
        public ICollection<AddOrderItem> Items { get; set; }
    }
    public class AddOrderItem
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
