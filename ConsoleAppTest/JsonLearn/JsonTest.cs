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

            jsonString = File.ReadAllText("test2.json");
            WeatherForecast weatherForecast2 = new WeatherForecast();
            weatherForecast2 = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
        }
    }

    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }

        private Pos referencePointX = new Pos(1, 2, 3);
        public Pos ReferencePointX
        {
            get
            {
                return referencePointX;
            }
            set { 
                referencePointX.X = value.X;
                referencePointX.Y = value.Y;
                referencePointX.Z = value.Z;
            }

        }

    }


    public class Pos
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Pos(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

    }
}
