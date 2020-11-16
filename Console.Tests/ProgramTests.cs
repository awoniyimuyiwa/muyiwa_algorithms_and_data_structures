using System;
using System.CommandLine;
using System.Collections.Generic;
using System.CommandLine.IO;
using System.Text;
using Xunit;

namespace Console.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("addition-pairs --numbers:4 6 2 8 --x:6", "4, 2")]
        [InlineData("addition-pairs -n:4 6 2 8 -x:6", "4, 2")]
        [InlineData("addition-pairs -numbers:4 6 2 8 -x:50", "No addition pairs found for 50")]

        [InlineData("binary-search --needle:cat --haystack:lion cat tiger --verbose", "Result: 1")]
        [InlineData("binary-search -n:lion -hs:lion cat tiger -v", "Result: 2")]
        [InlineData("binary-search -n:leopard -hs:lion cat tiger -v", "leopard was not found in haystack")]

        [InlineData("bst-traverse lion cat tiger", "In-order traverse: cat lion tiger", "Pre-order traverse: lion cat tiger", "Post-order traverse: cat tiger lion")]

        [InlineData("fib 5", "Result: 5")]
        
        [InlineData("fib-seq --to:5", "Result: 0 1 1 2 3 5")]
        [InlineData("fib-seq --from:0 --to:5", "Result: 0 1 1 2 3 5")]
        [InlineData("fib-seq --from:5 --to:0", "Result: 5 3 2 1 1 0")]
        [InlineData("fib-seq -f:0 -t:5", "Result: 0 1 1 2 3 5")]

        [InlineData("is-palindrome 51515", "True")]
        [InlineData("is-palindrome hello", "False")]

        [InlineData("merge-sort dog lion cat", "Result: cat dog lion")]
        
        [InlineData("multip-pairs -n:4 6 2 8 -x:8", "4, 2")]
        [InlineData("multip-pairs -n:4 6 2 8 -x:50", "No multiplication pairs found for 50")]

        [InlineData("num-occur --text:helloworld --pattern:hello", "Result: 1")]
        [InlineData("num-occur -t:helloworld -p:hello", "Result: 1")]

        [InlineData("num-occur-each-char helloworld", "h: 1", "e: 1", "l: 3", "o: 2", "w: 1", "r: 1", "d: 1")]

        [InlineData("num-words hello", "Result: 1")]

        [InlineData("num-to-words -1", "Result: Minus one")]
        [InlineData("num-to-words 0", "Result: Zero")]
        [InlineData("num-to-words 10", "Result: Ten")]
        [InlineData("num-to-words 11", "Result: Eleven")]
        [InlineData("num-to-words 12", "Result: Twelve")]
        [InlineData("num-to-words 13", "Result: Thirteen")]
        [InlineData("num-to-words 14", "Result: Fourteen")]
        [InlineData("num-to-words 15", "Result: Fifteen")]
        [InlineData("num-to-words 16", "Result: Sixteen")]
        [InlineData("num-to-words 17", "Result: Seventeen")]
        [InlineData("num-to-words 18", "Result: Eighteen")]
        [InlineData("num-to-words 19", "Result: Nineteen")]
        [InlineData("num-to-words 20", "Result: Twenty")]
        [InlineData("num-to-words 21", "Result: Twenty one")]
        [InlineData("num-to-words 22", "Result: Twenty two")]
        [InlineData("num-to-words 30", "Result: Thirty")]
        [InlineData("num-to-words 33", "Result: Thirty three")]
        [InlineData("num-to-words 40", "Result: Fourty")]
        [InlineData("num-to-words 44", "Result: Fourty four")]
        [InlineData("num-to-words 50", "Result: Fifty")]
        [InlineData("num-to-words 55", "Result: Fifty five")]
        [InlineData("num-to-words 60", "Result: Sixty")]
        [InlineData("num-to-words 66", "Result: Sixty six")]
        [InlineData("num-to-words 70", "Result: Seventy")]
        [InlineData("num-to-words 77", "Result: Seventy seven")]
        [InlineData("num-to-words 80", "Result: Eighty")]
        [InlineData("num-to-words 88", "Result: Eighty eight")]
        [InlineData("num-to-words 90", "Result: Ninety")]
        [InlineData("num-to-words 99", "Result: Ninety nine")]
        [InlineData("num-to-words 100", "Result: One hundred")]
        [InlineData("num-to-words 999", "Result: Nine hundred ninety nine")]
        [InlineData("num-to-words 1000", "Result: One thousand")]
        [InlineData("num-to-words 111111", "Result: One hundred eleven thousand one hundred eleven")]
        [InlineData("num-to-words 1000000", "Result: One million")]
        [InlineData("num-to-words 222222222", "Result: Two hundred twenty two million two hundred twenty two thousand two hundred twenty two")]
        [InlineData("num-to-words 1000000000", "Result: one billion")]
        [InlineData("num-to-words 333333333333", "Result: Three hundred thirty three billion three hundred thirty three million three hundred thirty three thousand three hundred thirty three")]
        [InlineData("num-to-words 1000000000000", "Result: one trillion")]
        [InlineData("num-to-words 444444444444444", "Result: Four hundred fourty four trillion four hundred fourty four billion four hundred fourty four million four hundred fourty four thousand four hundred fourty four")]
        [InlineData("num-to-words 1000000000000000", "Result: one quadrillion")]
        [InlineData("num-to-words 555555555555555555", "Result: Five hundred fifty five quadrillion five hundred fifty five trillion five hundred fifty five billion five hundred fifty five million five hundred fifty five thousand five hundred fifty five")]
        [InlineData("num-to-words 1000000000000000000", "Result: One quintillion")]
        [InlineData("num-to-words 9999999999999999999", "Result: Nine quintillion nine hundred ninety nine quadrillion nine hundred ninety nine trillion nine hundred ninety nine billion nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine")]
        [InlineData("num-to-words 9999999999999999999.999999999", "Result: nine quintillion nine hundred ninety nine quadrillion nine hundred ninety nine trillion nine hundred ninety nine billion nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine point one hundred")]

        [InlineData("proj-euler-prob-54 --hand1:5H 5C 6S 7S KD --hand2:2C 3S 8S 8D TD", "Player 2")]
        [InlineData("proj-euler-prob-54 -h1:5D 8C 9S JS AC -h2:2C 5C 7D 8S QH", "Player 1")]
        [InlineData("proj-euler-prob-54 -h1:2D 9C AS AH AC -h2:3D 6D 7D TD QD", "Player 2")]
        [InlineData("proj-euler-prob-54 -h1:4D 6S 9H QH QC -h2:3D 6D 7H QD QS", "Player 1")]
        [InlineData("proj-euler-prob-54 -h1:2H 2D 4C 4D 4S -h2:3C 3D 3S 9S 9D", "Player 1")]
        [InlineData("proj-euler-prob-54 -h1:5D 8C 9S JS AC -h2:5D 8C 9S JS AC", "No winner")]
        // One pair
        [InlineData("proj-euler-prob-54 -h1:5D 5C 4S 3S QC -h2:5D 5C 4S 3S QC", "No winner")]
        // Two pairs
        [InlineData("proj-euler-prob-54 -h1:5D 5C 4S 4S QC -h2:5D 5C 4S 4S QC", "No winner")]
        // Three of a kind
        [InlineData("proj-euler-prob-54 -h1:5D 5C 5S 4S QC -h2:5D 5C 5S 4S QC", "No winner")]
        // Straight
        [InlineData("proj-euler-prob-54 -h1:2D 3C 4S 5S 6C -h2:2D 3C 4S 5S 6C", "No winner")]
        [InlineData("proj-euler-prob-54 -h1:2D 3C 4S 5H QD -h2:2D 3C 4S 5S QD", "No winner")]
        // Flush
        [InlineData("proj-euler-prob-54 -h1:5D 4D 6D 2D 7D -h2:5D 4D 6D 2D 7D", "No winner")]
        // Full house
        [InlineData("proj-euler-prob-54 -h1:2D 2C 2S 3H 3D -h2:2D 2C 2S 3H 3D", "No winner")]
        // Four of a kind
        [InlineData("proj-euler-prob-54 -h1:2D 2C 2S 2H 3D -h2:2D 2C 2S 2H 3D", "No winner")]
        // Straight flush
        [InlineData("proj-euler-prob-54 -h1:2D 3D 4D 5D 6D -h2:2D 3D 4D 5D 6D", "No winner")]
        // Royal flush
        [InlineData("proj-euler-prob-54 -h1:TD JD QD KC AC -h2:TD JD QD KC AC", "No winner")]

        [InlineData("quick-sort lion cat tiger", "Result: cat lion tiger")]

        [InlineData("rem-all-cons-char foobarrbazz", "Result: fobarbaz")]

        [InlineData("rem-cons-char --text:foo --character:o", "Result: fo")]
        [InlineData("rem-cons-char -t:foo -c:o", "Result: fo")]

        [InlineData("rem-cons-word-dels hello\t\tworld", "Result: hello\tworld")]

        [InlineData("reverse helloworld", "dlrowolleh")]

        [InlineData("weather-to-json --temp:50 --summary:hot", "{", "\"temperatureInCelsius\": 50", "\"summary\": \"hot\"", "}")]
        [InlineData("weather-to-json -t:50 -s:hot", "{", "\"temperatureInCelsius\": 50", "\"summary\": \"hot\"", "}")]
        public void Run_WhenCalledWithValidArgs_OutputsValidText(string command, params string[] expecteds)
        {
            var args = command.Split(" ");
            var console = GetCustomConsole();

            Program.Run(args, console);

            var ouput = console.GetContentOfOutputStreamWriter();
            Assert.Contains(new List<string>(expecteds), expected => ouput.Contains(expected, StringComparison.OrdinalIgnoreCase));
        }

        [Theory]
        [InlineData("--help", 0)]
        [InlineData("-h", 0)]

        [InlineData("addition-pairs --numbers:4 6 2 8 --x:6", 0)]
        [InlineData("addition-pairs -n:4 6 2 8 -x:6", 0)]

        [InlineData("binary-search --needle:cat --haystack:lion cat tiger --verbose", 0)]
        [InlineData("binary-search -n:lion -hs:lion cat tiger", 0)]
        [InlineData("binary-search -n:leopard -hs:lion cat tiger", 0)]

        [InlineData("bst-traverse lion cat tiger", 0)]

        [InlineData("fib 5", 0)]

        [InlineData("fib-seq --to:5", 0)]
        [InlineData("fib-seq --from:0 --to:5", 0)]
        [InlineData("fib-seq --from:5 --to:0", 0)]
        [InlineData("fib-seq -f:0 -t:5", 0)]

        [InlineData("is-palindrome 51515", 0)]
        [InlineData("is-palindrome hello", 0)]

        [InlineData("merge-sort dog lion cat", 0)]

        [InlineData("multip-pairs --numbers:4 6 2 8 --x:8", 0)]
        [InlineData("multip-pairs -n:4 6 2 8 -x:8", 0)]
        [InlineData("multip-pairs -n:4 6 2 8 -x:50", 0)]

        [InlineData("num-occur --text:helloworld --pattern:hello", 0)]
        [InlineData("num-occur -t:helloworld -p:hello", 0)]

        [InlineData("num-occur-each-char helloworld", 0)]

        [InlineData("num-words hello", 0)]

        [InlineData("num-to-words 1", 0)]

        [InlineData("proj-euler-prob-54 --hand1:5H 5C 6S 7S KD --hand2:2C 3S 8S 8D TD", 0)]
        [InlineData("proj-euler-prob-54 -h1:5H 5C 6S 7S KD -h2:2C 3S 8S 8D TD", 0)]

        [InlineData("quick-sort lion cat tiger", 0)]

        [InlineData("rem-all-cons-char foobarrbazz", 0)]

        [InlineData("rem-cons-char --text:foo --character:o", 0)]
        [InlineData("rem-cons-char -t:foo -c:o", 0)]

        [InlineData("rem-cons-word-dels hello\t\tworld", 0)]

        [InlineData("reverse helloworld", 0)]

        [InlineData("weather-to-json --temp:50 --summary:hot", 0)]
        [InlineData("weather-to-json -t:50 -s:hot", 0)]
        public void Run_WhenCalledWithValidArgs_ReturnsValidResult(string command, int expected)
        {
            var args = command.Split(" ");
            var console = GetCustomConsole();

            var actual = Program.Run(args, console);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("addition-pairs --numbers:4 6 2 8", 1)]
        [InlineData("addition-pairs -x:6", 1)]

        [InlineData("binary-search --needle:cat", 1)]
        [InlineData("binary-search --haystack:lion cat tiger", 1)]

        [InlineData("bst-traverse", 1)]

        [InlineData("fib", 1)]
        [InlineData("fib -1", 1)]

        [InlineData("fib-seq", 1)]
        [InlineData("fib-seq -to:-1", 1)]
        [InlineData("fib-seq --from:-1 -to:-1", 1)]

        [InlineData("is-palindrome", 1)]

        [InlineData("merge-sort", 1)]

        [InlineData("multip-pairs --numbers:4 6 2 8", 1)]
        [InlineData("multip-pairs -x:8", 1)]

        [InlineData("num-occur --pattern:hello", 1)]
        [InlineData("num-occur --text:helloworld", 1)]

        [InlineData("num-occur-each-char", 1)]

        [InlineData("num-words", 1)]

        [InlineData("num-to-words", 1)]
        [InlineData("num-to-words 9999999999999999999.9999999999", 1)]

        [InlineData("proj-euler-prob-54 -h2:2C 3S 8S 8D TD", 1)]
        [InlineData("proj-euler-prob-54 -h1:5H 5C 6S 7S KD", 1)]
        [InlineData("proj-euler-prob-54 -h1:5 6S 7S KD -h2:2C 3S 8S 8D TD", 1)]
        [InlineData("proj-euler-prob-54 -h1:5H 6S 7S KD -h2:2 3S 8S 8D TD", 1)]
        [InlineData("proj-euler-prob-54 -h1:AH 6S 7S KD -h2:2C 3S 8S 8D TD", 1)]
        [InlineData("proj-euler-prob-54 -h1:5H 6S 7S KD -h2:AC 3S 8S 8D TD", 1)]
        [InlineData("proj-euler-prob-54 -h1:5h 6S 7S KD -h2:2C 3S 8S 8D TD", 1)]
        [InlineData("proj-euler-prob-54 -h1:5H 6S 7S KD -h2:2c 3S 8S 8D TD", 1)]
       
        [InlineData("quick-sort", 1)]

        [InlineData("rem-all-cons-char", 1)]

        [InlineData("rem-cons-char --character:o", 1)]
        [InlineData("rem-cons-char -text:foo", 1)]

        [InlineData("rem-cons-word-dels", 1)]

        [InlineData("reverse", 1)]

        [InlineData("weather-to-json --temp:50", 1)]
        [InlineData("weather-to-json --summary:hot", 1)]
        public void Run_WhenCalledWithInValidArgs_ReturnsValidResult(string command, int expected)
        {
            var args = command.Split(" ");
            var console = GetCustomConsole();

            var actual = Program.Run(args, console);

            Assert.Equal(expected, actual);
        }

        CustomConsole GetCustomConsole() => new CustomConsole();
    }

    class CustomConsole : IConsole
    {
        readonly CustomStreamWriter OutputStreamWriter;
        readonly CustomStreamWriter ErrorStreamWriter;
        public CustomConsole()
        {
            OutputStreamWriter = new CustomStreamWriter();
            ErrorStreamWriter = new CustomStreamWriter();
        }

        public IStandardStreamWriter Out => OutputStreamWriter;

        public bool IsOutputRedirected => true;

        public IStandardStreamWriter Error => ErrorStreamWriter;

        public bool IsErrorRedirected => true;

        public bool IsInputRedirected => true;

        public string GetContentOfOutputStreamWriter()
        {
            return OutputStreamWriter.GetContent();
        }
        public string GetContentOfErrorStreamWriter()
        {
            return ErrorStreamWriter.GetContent();
        }
    }

    class CustomStreamWriter : IStandardStreamWriter
    {
        readonly StringBuilder StringBuilder;

        public CustomStreamWriter()
        {
            StringBuilder = new StringBuilder();
        }

        public void Write(string value)
        {
            StringBuilder.Append(value);
        }

        public string GetContent()
        {
            return StringBuilder.ToString();
        }
    }
}
