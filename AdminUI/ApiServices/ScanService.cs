using AdminUI.Objects.Response;
using System.Net.Http.Json;

namespace AdminUI.ApiServices
{
    public class ScanService(HttpClient http)
    {
        public async Task<ScanResponse> ScanAll(string rfid)
        {
            var res = await http.GetFromJsonAsync<ScanResponse>("api/Scan/scan-all/" + rfid);
            return res;
        }
    }
}
