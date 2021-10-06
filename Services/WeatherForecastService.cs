using HomeIoT.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System;

public class WeatherForecastService
{
    private readonly IHttpClientFactory _clientFactory;
    private WeatherForecast weather;
    public bool error = false;
    private string id = /*insert id*/;


    public WeatherForecastService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<WeatherForecast> GetWeather()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?zip=23464&appid={id}&units=imperial");

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        weather = JsonSerializer.Deserialize<WeatherForecast>(result);
        return weather;
    }
}
