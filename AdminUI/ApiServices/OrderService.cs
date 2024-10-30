using AdminUI.Objects;
using AdminUI.Objects.Request;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace AdminUI.ApiServices
{
    public class OrderService(HttpClient http, ILocalStorageService localStorage)
    {
        public async Task<ExportModel> CreateAsync(OrderRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var response = await http.PostAsJsonAsync("api/Order/create", request);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<ExportResponse>();

            return data.Data;
        }
        public async Task<bool> CancelAsync(int id)
        {
            var res = await http.PostAsJsonAsync("api/Order/cancel", id);
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
