using AdminUI.Objects;

namespace AdminUI.Services
{
    public class ProductService
    {
        public static List<ProductModel> FakeData { get; set; }
        public static async Task<List<ProductModel>> GetFakeData()
        {
            if (FakeData == null)
                FakeData = await ProductModel.GenData();
            return FakeData;
        }
    }
}
