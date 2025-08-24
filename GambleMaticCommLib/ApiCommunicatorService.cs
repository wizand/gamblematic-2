using System.Text.Json;

namespace GambleMaticCommLib;

public class ApiCommunicatorService
{
    private readonly JwtHelper _tokenHolder;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient? _httpClient = null;
    private HttpClient HttpClient => _httpClient ?? _httpClientFactory.CreateClient("GamblematicApiHttpClient");


    public ApiCommunicatorService(IHttpClientFactory httpClientFactory, JwtHelper tokenHolder)
    {
        _tokenHolder = tokenHolder;
        _httpClientFactory = httpClientFactory;
    }


    public async Task<string> GetToken()
    {
        return await _tokenHolder.GetTokenString();
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

            var result = JsonSerializer.Deserialize<T>(content);
            ApiResult<T> apiResult = new ApiResult<T>(payload: result, error: null);
            return apiResult;
        }
        else
        {
            return new ApiResult<T>
            (
                error: new ApiError(errorMessage: response.ReasonPhrase ?? response.StatusCode.ToString())
            );
        }
    }








}