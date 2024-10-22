using System.ComponentModel.DataAnnotations;

namespace AdminUI.Objects
{
    public class ProductDetails
    {
        //[StringLength(50)]
        public string Name { get; set; }

        //[Range(0, 9000000000)]
        public double Price { get; set; }

        //[Range(0, 9000000000)]
        public double ImportPrice { get; set; }

        public int Quantity { get; set; }

        public bool Discontinued { get; set; }

        public bool Deleted { get; set; }

        //[StringLength(150)]
        public string? Photo { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; } //FK

        public int? BrandId { get; set; } //FK

        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
