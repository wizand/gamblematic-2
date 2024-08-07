namespace GambleMaticWebUi.Data.ViewModels
{
    public class WeatherForecastViewModel
    {


        public WeatherForecastViewModel(GambleMaticCommLib.DataModels.WeatherForecastDto weatherForecastDto)
        {
            this.Date = weatherForecastDto.Date;
            this.TemperatureC = weatherForecastDto.TemperatureC;
            this.Summary = weatherForecastDto.Summary;

        }

        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);


    }
}
