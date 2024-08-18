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
        WeatherForecastProvider = new(this);
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
                    Message = response.ReasonPhrase ?? response.StatusCode.ToString()
                }
            );
        }
    }


    public WeatherForecastProvider WeatherForecastProvider { get; set; }
}



public class WeatherForecastProvider
{

    public WeatherForecastProvider(ApiCommunicatorService apiCommunicatorService)
    {
        this._apiCommunicatorService = apiCommunicatorService;
    }
    private ApiCommunicatorService _apiCommunicatorService;




    public async Task<ApiResult<WeatherForecastDto>> GetForecasts()
    {

        var token = await _apiCommunicatorService.GetToken();





        await Task.Delay(Random.Shared.Next(0,500));
        WeatherForecastDto[] forecasts;

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();

        ApiResult<WeatherForecastDto> result = new(forecasts, true, null );

        return result;
    }


}