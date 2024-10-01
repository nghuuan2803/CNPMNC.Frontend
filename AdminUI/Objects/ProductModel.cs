

namespace AdminUI.Objects
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string? Photo { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public bool Discontinued { get; set; }

        public ProductModel(int id, string name, int quantity, double price)
        {
            Id = id;
            Name = name;
            //Description = description;
            Quantity = quantity;
            Price = price;
        }

        public ProductModel()
        {
        }

        public ProductModel(int id, string name, double price, int quantity, string? photo, string? description, int categoryId, int brandId, bool discontinued)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Photo = photo;
            Description = description;
            CategoryId = categoryId;
            BrandId = brandId;
            Discontinued = discontinued;
        }
        public ProductModel(ProductModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Price = model.Price;
            Quantity = model.Quantity;
            Photo = model.Photo;
            Description = model.Description;
            CategoryId = model.CategoryId;
            BrandId = model.BrandId;
            Discontinued = model.Discontinued;
        }
        public static async Task<List<ProductModel>> GenData()
        {
            var list = new List<ProductModel>();
            for (int i = 1; i <= 2000; i++)
            {
                list.Add(new ProductModel(i, "product " + i, 100 + (i * 10), 1000000 + (i * 500000)));
                //list.Add(new ProductModel(i,"product "+((char)(i+64)).ToString(),Lorem.Paragraph(),100+(i*10),1000000+(i*500000)));
            }
            return list;
        }
    }
}
