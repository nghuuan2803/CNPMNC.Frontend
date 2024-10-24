namespace AdminUI.Objects
{
    public class SelectImportItem
    {
        public int Id { get; set; }

        public string ImportId { get; set; }
        public string ProductId { get; set; }

        public string Name { get; set; }

        public double ImportPrice { get; set; }

        public int ImportQty { get; set; }

        public string? Photo { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public int Number { get; set; }
    }
}
