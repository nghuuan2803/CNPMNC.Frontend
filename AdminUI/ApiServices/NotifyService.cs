using AdminUI.Objects.Response;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace AdminUI.ApiServices
{
    public class NotifyService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        public async Task<List<Notification>> GetAll()
        {
            string sender = "EMP001";
            try
            {
                var list = await httpClient.GetFromJsonAsync<List<Notification>>("api/Notify/get-all/"+sender);
                return list;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task Checked(int id)
        {
            var res = await httpClient.GetAsync("api/Notify/get-all");
            res.EnsureSuccessStatusCode();
        }
    }
}
