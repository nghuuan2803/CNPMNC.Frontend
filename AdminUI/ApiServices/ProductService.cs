using AdminUI.Objects;
using AdminUI.Objects.Response;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace AdminUI.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public ProductService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _http = httpClient;
            _localStorage = localStorage;
        }


        public static List<ProductModel> FakeData { get; set; }
        public static async Task<List<ProductModel>> GetFakeData()
        {
            if (FakeData == null)
                FakeData = await ProductModel.GenData();
            return FakeData;
        }

        #region TokenHandler
        private async Task<string> GetAccessTokenAsync()
        {
            var result = await _localStorage.GetItemAsync<string>("jwt_token");

            // Loại bỏ dấu ngoặc kép nếu cần
            var token = result?.Replace("\"", "");

            return token; // Trả về token đã được loại bỏ dấu ngoặc kép
        }
        private async Task AddJwtHeader()
        {
            var jwtToken = await GetAccessTokenAsync();
            if (!string.IsNullOrEmpty(jwtToken))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
            else
            {
                throw new Exception("không có Jwt token");
            }
        }
        #endregion
        #region CRUD
        public async Task<List<ProductModel>> GetAllAsync()
        {
            try
            {
                //await AddJwtHeader();
                var result = await _http.GetFromJsonAsync<ListProductResponse>("api/Product/get-all");
                return result.Data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public async Task<int> CreateAsync(CreateProduct model)
        //{
        //    try
        //    {
        //        //await AddJwtHeader();
        //        // Gửi POST request tới API
        //        var response = await _http.PostAsJsonAsync("api/Product/create", model);

        //        // Kiểm tra kết quả
        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Đọc dữ liệu trả về từ API (ID sản phẩm)
        //            var product = await response.Content.ReadFromJsonAsync<ProductResponse>();
        //            return product.Data.Id;
        //        }
        //        else
        //        {
        //            return -1;
        //            //throw new Exception("Failed to create product");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý ngoại lệ
        //        Console.WriteLine($"Error: {ex.Message}");
        //        throw new Exception("API call failed");
        //    }
        //}
        public async Task<ProductModel> CreateAsync(CreateProduct model)
        {
            try
            {
                //await AddJwtHeader();
                var productJson = System.Text.Json.JsonSerializer.Serialize(model.Data);

                var content = new MultipartFormDataContent();
                var stream = model.ImageFile.OpenReadStream();
                var fileContent = new StreamContent(stream);
                content.Add(fileContent, "file", model.ImageFile.Name);

                // Gửi yêu cầu tới API
                var response = await _http.PostAsync("/api/Product/upload-image", content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error while calling API.");
                }
                // Kiểm tra kết quả
                // Đọc dữ liệu trả về từ API (ID sản phẩm)
                var product = await response.Content.ReadFromJsonAsync<ProductResponse>();
                return product.Data;

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
                //await AddJwtHeader();
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
            await AddJwtHeader();
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
        public async Task<bool> Delete(string id)
        {
            //await AddJwtHeader();
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
            await AddJwtHeader();
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
            await AddJwtHeader();
            var response = await _http.GetAsync("api/Product/export-excel");
            //
        }
        #endregion
        public class CreateProductResult
        {
            public string ImageLink { get; set; }
        }
    }
}
