using AdminUI.Objects;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace AdminUI.ApiServices
{
    public class SuplierServices(HttpClient _http, ILocalStorageService _localStorage)
    {
        public async Task<List<SuplierModel>> GetAllAsync()
        {
            var response = await _http.GetFromJsonAsync<SuplierListResponse>("api/Suplier/get-all");
            return response.Data;
        }
    }
}
