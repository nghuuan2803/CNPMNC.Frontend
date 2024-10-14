namespace AdminUI.Objects
{
    public class SelectImportItem
    {
        public int Id { get; set; }

        public int ImportId { get; set; }
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double ImportPrice { get; set; }

        public int ImportQty { get; set; }

        public string? Photo { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }
    }
}
