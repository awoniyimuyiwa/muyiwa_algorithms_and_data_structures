using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class SerializeToJsonTests
    {
        [Theory]
        [InlineData(50, "extremely hot", "{", "\"temperatureInCelsius\": 50", "\"summary\": \"extremely hot\"", "}")]
        public void Run_WhenCalled_ReturnsValidResult(double temperature, string summary, params string[] expecteds)
        {
            var actual = SerializeToJson.Run(temperature, summary);

            Assert.Contains(new List<string>(expecteds), expected => actual.Contains(expected, StringComparison.OrdinalIgnoreCase));
        }
    }
}
