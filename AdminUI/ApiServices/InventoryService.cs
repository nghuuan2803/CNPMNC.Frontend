using AdminUI.Objects;
using AdminUI.Objects.Request;
using AutoMapper;
using System.Net.Http.Json;

namespace AdminUI.ApiServices
{
    public class InventoryService(HttpClient http,IMapper mapper)
    {
        public async Task<List<InventoryModel>> GetAll()
        {
            var data = await http.GetFromJsonAsync<List<InventoryModel>>("api/Inventory/get-all");
            return data;
        }
        public async Task<List<InventoryModel>> GetbyProduct(string id)
        {
            var data = await http.GetFromJsonAsync<List<InventoryModel>>("api/Inventory/get-by-product/"+id);
            return data;
        }
        public async Task<MergeModel> MergeAsync(MergeInventoryRequest request)
        {
            var res = await http.PostAsJsonAsync("api/Inventory/merge", request);
            res.EnsureSuccessStatusCode();
            var data = await res.Content.ReadFromJsonAsync<MergeModel>();
            return data;
        }
    }
}
