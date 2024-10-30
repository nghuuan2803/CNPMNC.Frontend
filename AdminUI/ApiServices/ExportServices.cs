using AdminUI.Objects;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AdminUI.ApiServices
{
    public class ExportServices
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public ExportServices(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _http = httpClient;
            _localStorage = localStorage;
        }

        public async Task<List<ExportModel>> GetAllAsync()
        {
            try
            {
                //await AddJwtHeader();
                var result = await _http.GetFromJsonAsync<ExportListResponse>("api/Export/get-all");
                return result.Data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ExportModel> ApprovalAsync(ExportModel model)
        {
            var res = await _http.PostAsJsonAsync("api/Export/approval", model);
            res.EnsureSuccessStatusCode();
            var data = await res.Content.ReadFromJsonAsync<ExportResponse>();
            if (data != null)
                return data.Data;
            return model;
        }
        public async Task<bool> CompleteAsync(ExportModel model)
        {
            var res = await _http.PostAsJsonAsync("api/Export/complete", model.Id);
            return res.IsSuccessStatusCode;
        }
        public async Task<bool> RefuseAsync(ExportModel model)
        {
            var res = await _http.PostAsJsonAsync("api/Export/refuse", model.Id);
            return res.IsSuccessStatusCode;
        }
        public async Task<bool> CancelAsync(ExportModel model)
        {
            var res = await _http.PostAsJsonAsync("api/Export/cancel", model.Id);
            return res.IsSuccessStatusCode;
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
