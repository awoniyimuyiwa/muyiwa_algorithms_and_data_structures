# Algorithms & Data structures
[![Build Status](https://dev.azure.com/muyiwaawoniyi/algorithms-data-structures/_apis/build/status/awoniyimuyiwa.muyiwa_algorithms_and_data_structures?branchName=master)](https://dev.azure.com/muyiwaawoniyi/algorithms-data-structures/_build/latest?definitionId=1&branchName=master)
[![Coverage Status](https://coveralls.io/repos/github/awoniyimuyiwa/muyiwa_algorithms_and_data_structures/badge.svg?branch=master)](https://coveralls.io/github/awoniyimuyiwa/muyiwa_algorithms_and_data_structures?branch=master)

> Implements common algorithms and data structures

* Ensure you have installed [dotnet 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1).
* From your CLI, navigate to Console folder of the solution and run any of the following commands:

```bash
# Show help and usage information
$ dotnet run -- -h

# Run algorithms
$ dotnet run algo addition-pairs --numbers:4 6 2 8 --x:6
$ dotnet run algo binary-search --needle:cat --haystack:lion cat tiger --verbose
$ dotnet run algo bst-traverse lion cat tiger
$ dotnet run algo fib 5
$ dotnet run algo fib-seq --to:5
$ dotnet run algo fib-seq --from:0 --to:5
$ dotnet run algo fib-seq --from:5 --to:0
$ dotnet run algo is-palindrome 51515
$ dotnet run algo merge-sort dog lion cat
$ dotnet run algo multip-pairs --numbers:4 6 2 8 --x:8
$ dotnet run algo num-occur --text:"hello world" --pattern:hello
$ dotnet run algo num-occur-each-char "hello world"
$ dotnet run algo num-words "hello world"
$ dotnet run algo proj-euler-prob-54 --hand1:5H 5C 6S 7S KD --hand2:2C 3S 8S 8D TD
$ dotnet run algo quick-sort lion cat tiger
$ dotnet run algo rem-all-cons-char foobarrbazz
$ dotnet run algo rem-cons-char --text:foo --character:o
$ dotnet run algo rem-cons-word-dels "hello      world"
$ dotnet run algo reverse "hello world"
$ dotnet run algo weather-to-json --temp:50 --summary:"Extremely hot"
```

### Unit Tests ###

* From your CLI, navigate to the root of the solution and run the following command:

```bash
$ dotnet test
```

### Who do I talk to? ###

*  [Muyiwa Awoniyi](mailto:muyiwaawoniyi@yahoo.com)