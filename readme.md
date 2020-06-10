# Dotnet core - Python processes benchmark project
This project tries to defeat a benchmark communicating two separare processes: one written in dotnet core 3.1 producing data, and another one, written in python 3.7, consuming these data.

The producer process is generating data items of 1,700 double numbers.
The consumer must ingest this information as fast as possible.

The record to break is ingest 300K doubles values (or 177 data items)

Both processes will run on a 8 core server. You can see full details of the instance in this image:
![Server configuration](/img/server_conf.png)

## Assumptions

1. Both processes are running on the same server on same time
2. IPC techniques will probably fit best here in terms of performance, but other options could be explored.

## Aproaches
1. WIP. Branch Master

## Prerequisites

You need at least one server machine with docker installed. Due to the local nature of the challenge, no kubernetes was added to the solution, and all the containers are orchestrated via a docker-compose file.
The different technical approaches will be included in a separate branch of this project. You can swith between approaches using the command git branch. An index of all the solutions expored will be incluced in this documment in the master branch.

## Running the tests

The main purpose of this project is to explore the best performing interprocesses communication, so the testing, project structure, DI and CI tooling was reduced to its minimun expression.

Anyway, a bare set of tests were created and you can execute them using the folloing commands:

```
	dotnet restore
	dotnet build
	dotnet test ./producer/tests/producer_tests.csproj
```

## Built With

* [Visual Studio 2019](https://visualstudio.microsoft.com/)
* [Dotnet Core 3.1](https://dotnet.microsoft.com/download/dotnet-core)
* [Python 3.7](https://www.python.org/downloads/)

## Versioning

We use [github](https://github.com/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Angel Castro** - *Initial work* - [AngelCastro](https://github.com/alcastrob/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
