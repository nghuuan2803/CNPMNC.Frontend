using AdminUI.Objects;
using AdminUI.Objects.Response;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
namespace AdminUI.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient httpClient)
        {
            _http = httpClient;
        }
        public ProductService() { }


        public static List<ProductModel> FakeData { get; set; }
        public static async Task<List<ProductModel>> GetFakeData()
        {
            if (FakeData == null)
                FakeData = await ProductModel.GenData();
            return FakeData;
        }
        public async Task<List<ProductModel>> GetAllAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ListProductResponse>("api/Product/get-all");
                return result.Data;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw new Exception(message: "Goi API that bai");
            }
        }
        public async Task<int> CreateAsync(ProductModel model)
        {
            try
            {
                // Gửi POST request tới API
                var response = await _http.PostAsJsonAsync("api/Product/create", model);

                // Kiểm tra kết quả
                if (response.IsSuccessStatusCode)
                {
                    // Đọc dữ liệu trả về từ API (ID sản phẩm)
                    var product = await response.Content.ReadFromJsonAsync<ProductResponse>();
                    return product.Data.Id;
                }
                else
                {
                    return -1;
                    //throw new Exception("Failed to create product");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("API call failed");
            }
        }
        public async Task<List<ProductModel>> CreateMultipleAsync(List<ProductModel> model)
        {
            try
            {
                // Gửi POST request tới API
                var response = await _http.PostAsJsonAsync("api/Product/create-multiple", model);

                // Kiểm tra kết quả
                if (response.IsSuccessStatusCode)
                {
                    // Đọc dữ liệu trả về từ API (ID sản phẩm)
                    var product = await response.Content.ReadFromJsonAsync<ListProductResponse>();
                    return product.Data;
                }
                else
                {
                    return null!;
                    //throw new Exception("Failed to create product");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("API call failed");
            }
        }
        public async Task<bool> Update(ProductModel model)
        {
            try
            {
                // Gửi POST request tới API
                var response = await _http.PutAsJsonAsync("api/Product/update", model);
                var msg = await response.Content.ReadFromJsonAsync<MessageResponse>();
                Console.WriteLine(msg.Message);
                // Kiểm tra kết quả
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"API call failed");
                //throw new Exception("API call failed");
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                // Gửi yêu cầu DELETE tới API
                var response = await _http.DeleteAsync($"api/Product/delete/{id}");
                var msg = await response.Content.ReadFromJsonAsync<MessageResponse>();
                Console.WriteLine(msg.Message);
                // Kiểm tra nếu yêu cầu thành công (status code 200-299)
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình gọi API
                Console.WriteLine($"Error: {ex.Message}");
                return false; // Xóa thất bại do lỗi
            }
        }
        public async Task<bool> Recover(ProductModel model)
        {
            try
            {
                // Gửi POST request tới API
                var response = await _http.PutAsJsonAsync("api/Product/recover", model.Id);
                var msg = await response.Content.ReadFromJsonAsync<MessageResponse>();
                Console.WriteLine(msg.Message);
                // Kiểm tra kết quả
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"API call failed");
                //throw new Exception("API call failed");
                return false;
            }
        }
        public async Task ExportExcel()
        {
            var response = await _http.GetAsync("api/Product/export-excel");
            //
        }
    }
}
