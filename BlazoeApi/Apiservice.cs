using System.Net.Http;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string ESP32_IP = "https://sleep.fifux.be";

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> FetchCurrentValue()
    {
        try
        {
            return await _httpClient.GetStringAsync($"{ESP32_IP}/get?id=7");
        }
        catch
        {
            return null;
        }
    }
}
