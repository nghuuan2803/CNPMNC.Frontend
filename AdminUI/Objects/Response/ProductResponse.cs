namespace AdminUI.Objects.Response
{
    public class ListProductResponse
    {
        public string Message { get; set; }
        public List<ProductModel> Data { get; set; }
    }
    public class ProductResponse
    {
        public string Message { get; set; }
        public ProductModel Data { get; set; }
    }
}
