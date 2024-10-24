﻿using AdminUI.Objects.Response;
using AdminUI.Objects;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AdminUI.ApiServices
{
    public class EmployeeServices
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public EmployeeServices(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _http = httpClient;
            _localStorage = localStorage;
        }
        public EmployeeServices() { }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            try
            {
                //await AddJwtHeader();
                var result = await _http.GetFromJsonAsync<EmployeeListResponse>("api/Employee/get-all");
                return result.Data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateAsync(EmployeeModel model)
        {
            //await AddJwtHeader();

            try
            {
                // Gửi POST request tới API
                var response = await _http.PostAsJsonAsync("api/Employee", model);

                // Kiểm tra kết quả
                if (response.IsSuccessStatusCode)
                {
                    // Đọc dữ liệu trả về từ API (ID sản phẩm)
                    // var Employee = await response.Content.ReadFromJsonAsync<EmployeeResponse>();
                    return true;
                }
                else
                {
                    return false;
                    //throw new Exception("Failed to create Employee");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("API call failed");
            }
        }
        public async Task<bool> Update(EmployeeModel model)
        {
            //await AddJwtHeader();
            try
            {
                // Gửi POST request tới API
                var response = await _http.PutAsJsonAsync("api/Employee", model);
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
            await AddJwtHeader();
            try
            {
                // Gửi yêu cầu DELETE tới API
                var response = await _http.DeleteAsync($"api/Employee/delete/{id}");
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
    }
}
