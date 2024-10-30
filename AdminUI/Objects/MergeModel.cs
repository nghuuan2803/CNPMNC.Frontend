namespace AdminUI.Objects
{
    public class MergeModel
    {
        public int Id { get; set; }

        public DateTime MergeDate { get; set; }

        public string From { get; set; }
        public string FromWarehouse { get; set; }

        public string To { get; set; }
        public string ToWarehouse { get; set; }

        public string CreatedBy { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateOn { get; set; }
        public int Quantity { get; set; }

        public string? Note { get; set; }
    }
}
