using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlgorithmsAndDataStructures.Algorithms
{

    class SerializeToJsonImplementation
    {
        static string SerializeToJson()
        {
            var weatherForecast = new WeatherForeCast
            {
                DateTimeOffset = DateTimeOffset.UtcNow,
                TempratureC = 40,
                Summary = "Lovely weather, time to make things happen!"
            };

            var SerializationOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            return JsonSerializer.Serialize(weatherForecast, SerializationOptions);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******JSON SERIALIZATION*******");
            Console.WriteLine("Outputs an in-memory weather forecast object as json");

            Console.WriteLine(SerializeToJson());

            Console.WriteLine("*******END OF JSON SERIALIZATION\n*******");
        }
    }

    class WeatherForeCast
    {
        public DateTimeOffset DateTimeOffset { get; set; }

        [JsonPropertyName("temp")]
        public int TempratureC { get; set; }
        public string Summary { get; set; }
    }
}
