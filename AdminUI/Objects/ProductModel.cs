using Microsoft.AspNetCore.Components.Forms;

namespace AdminUI.Objects
{
    public class ProductModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double ImportPrice { get; set; }

        public int Quantity { get; set; }

        public string? Photo { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public bool Discontinued { get; set; }

        public ProductModel(string id, string name, double price, double importPrice, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Quantity = 0;
            Price = price;
            ImportPrice = importPrice;
        }

        public ProductModel()
        {
        }

        public ProductModel(string id, string name, double price, string? photo, string? description, int categoryId, int brandId, bool discontinued)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = 0;
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
                list.Add(new ProductModel(id:"SP" + i, name:"Sản phẩm " + i, price: 1000000 + (i * 500000), importPrice: 1000000 + (i * 500000)));
            }
            return list;
        }
    }

    public class CreateProduct
    {
        public ProductModel Data { get; set; }
        public IBrowserFile ImageFile { get; set; }
    }
}
