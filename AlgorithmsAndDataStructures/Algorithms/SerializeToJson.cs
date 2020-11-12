using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class SerializeToJson
    {
        /// <summary>
        /// Serializes an in-memory object to json
        /// </summary>
        /// <remarks>
        /// BEST CASE- TIME: Ω(1), MEMORY: Ω(1)
        /// AVERAGE CASE- TIME: Θ(1), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(1), MEMORY: O(1)
        /// </remarks>
        public static string Run(double temperature, string summary)
        {
            var weatherForecast = new WeatherForeCast
            {
                Date = DateTimeOffset.UtcNow.ToString("dd-MM-yyyy"),
                TemperatureC = temperature,
                Summary = summary
            };

            var SerializationOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            return JsonSerializer.Serialize(weatherForecast, SerializationOptions);
        }
    }

    class WeatherForeCast
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("temperatureInCelsius")]
        public double TemperatureC { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }
}
