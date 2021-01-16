using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace ConsoleAppTest.JsonLearn
{
    class JsonTest
    {
        public void TestData()
        {
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.Date = new DateTimeOffset();
            weatherForecast.TemperatureCelsius = 1;
            weatherForecast.Summary = "Hello World";

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;

            string jsonString = JsonSerializer.Serialize(weatherForecast, jsonSerializerOptions);
            Console.WriteLine(jsonString);
            File.WriteAllText("test.json", jsonString);
        }
    }

    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
}
