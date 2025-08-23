using System.Net.Http;
using System.Text.Json;
using System.Web;

using GambleMaticCommLib.DataModels;

namespace GambleMaticCommLib;

public class ApiCommunicatorService
{

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient? _httpClient = null;
    private HttpClient HttpClient => _httpClient ?? _httpClientFactory.CreateClient("GamblematicApiHttpClient");


    public ApiCommunicatorService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    public async Task<string> GetToken()
    {
        return "asd-asd-asd";
    }

    public async Task<ApiResult<T>> Get<T>(string url)
    {
        var token = await GetToken();

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Bearer {token}");

        var response = await HttpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<T[]>(content);
            ApiResult<T> apiResult = new(payload: result, success: true, error: null);
            return apiResult;
        }
        else
        {
            return new ApiResult<T>
            (
                payload: null,
                success: false,
                error: new ApiError()
                {
                    ErrorMessage = response.ReasonPhrase ?? response.StatusCode.ToString()
                }
            );
        }
    }








}