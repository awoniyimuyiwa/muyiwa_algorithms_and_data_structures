using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class SerializeToJson
    {
        /// <summary>
        /// Serializes an in-memory object to json
        /// </summary>
        /// <remarks>
        /// BEST CASE- TIME: Ω(1), MEMORY: Ω(1)
        /// AVERAGE CASE- TIME: Θ(1), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(1), MEMORY: O(1)
        /// </remarks>
        static string DoSerializeToJson(double temperature, string summary)
        {
            var weatherForecast = new WeatherForeCast
            {
                DateTimeOffset = DateTimeOffset.UtcNow,
                TemperatureC = temperature,
                Summary = summary
            };

            var SerializationOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            return JsonSerializer.Serialize(weatherForecast, SerializationOptions);
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******SERIALIZE TO JSON*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Outputs an in-memory weather forecast object as json:");

            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}Enter temperature in celsius: ");
            string temperatureInput = Console.ReadLine();
            // Validate input
            if (!double.TryParse(temperatureInput, out double temperature))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: temperature must be a valid number");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            const double lowestTemperatureInCelsius = -273.15;
            if (temperature < lowestTemperatureInCelsius)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: temperature in celsius must be at least {lowestTemperatureInCelsius}");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            const double highestTemperatureInCelsius = 1420000000000000000000000000000000.00; //1.42Nonillion
            if (temperature > highestTemperatureInCelsius)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: temperature in celsius cannot be greater than {string.Format("{0:0,0}", highestTemperatureInCelsius)}");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.WriteLine("Enter friendly weather summary: ");
            string summary = Console.ReadLine();
            if (string.IsNullOrEmpty(summary))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Summary must be provided");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Executing...");
            // Execute and display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}Result: ");
            Console.WriteLine(DoSerializeToJson(temperature, summary));

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF SERIALIZE TO JSON*******{Environment.NewLine}");
        }
    }

    class WeatherForeCast
    {
        public DateTimeOffset DateTimeOffset { get; set; }

        [JsonPropertyName("temperatureInCelsius")]
        public double TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
