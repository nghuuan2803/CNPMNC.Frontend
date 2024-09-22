using AdminUI.Objects;

namespace AdminUI.Services
{
    public class ProductService
    {
        public static List<ProductModel> FakeData { get; set; } = ProductModel.GenData();
    }
}
