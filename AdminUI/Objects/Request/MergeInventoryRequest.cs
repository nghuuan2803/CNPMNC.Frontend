namespace AdminUI.Objects.Request
{
    public class MergeInventoryRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string ManagerId { get; set; }
    }
}
