using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlgorithmsAndDataStructures.Algorithms
{

    class SerializeToJsonImplementation
    {
        /// <summary>
        /// Serializes an in-memory object to json
        /// </summary>
        /// <remarks>
        /// BEST CASE- TIME: Ω(1), MEMORY: Ω(1)
        /// AVERAGE CASE- TIME: Θ(1), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(1), MEMORY: O(1)
        /// </remarks>
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

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******JSON SERIALIZATION*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nOutputs an in-memory weather forecast object as json:");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nExecuting...");
            // Execute and display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(SerializeToJson());

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF JSON SERIALIZATION*******\n");
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
