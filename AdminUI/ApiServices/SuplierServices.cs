using AdminUI.Objects;
using AdminUI.Objects.Response;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace AdminUI.ApiServices
{
    public class SuplierService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public SuplierService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
        public SuplierService() { }

        // Phương thức này sẽ gọi API để thêm nhà cung cấp

        public async Task<List<SuplierModel>> GetAllSupliersAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ListSuplierModel>("api/Suplier/get-all");
                return result.Data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> CreateSuplierAsync(SuplierModel model)
        {
            try
            {
                // Gửi POST request tới API
                var response = await _httpClient.PostAsJsonAsync("api/suplier", model); //sai chinh ta

                if (response.IsSuccessStatusCode)
                { // Đọc dữ liệu trả về từ API (ID sản phẩm)
                    var suplier = await response.Content.ReadFromJsonAsync<SuplierResponse>();
                    return suplier.Data.Id;
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
        }// Trả về true nếu thành công, ngược lại là false
        public async Task<bool> Delete(int id)
        {
            //await AddJwtHeader();
            try
            {
                // Gửi yêu cầu DELETE tới API
                var response = await _httpClient.DeleteAsync($"api/Suplier/delete/"+id);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình gọi API
                Console.WriteLine($"Error: {ex.Message}");
                return false; // Xóa thất bại do lỗi
            }
        }
        public async Task<bool> Update(SuplierModel model)
        {
            try
            {
                // Gửi POST request tới API
                var response = await _httpClient.PutAsJsonAsync("api/Suplier", model);
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
    }
}
