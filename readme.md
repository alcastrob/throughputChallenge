# Dotnet core - Python processes benchmark project
Master branch: ![](https://travis-ci.com/alcastrob/throughputChallenge.svg?branch=master)

This project tries to defeat a benchmark communicating two separare processes: one written in dotnet core 3.1 producing data, and another one, written in python 3.7, consuming these data.

The producer process simulates to generate a bitmap of 1,700 pixels, with a pixel depth of 5 floats (or 160 bits/pixel).
The consumer must ingest this information as fast as possible.

The record to break is ingest **265 bitmaps of 1,700 pixels of 160 bits** in 30 seconds, (around 9M doubles values). To reach that level, **the average ingest must be around 9 bitmaps per second**.

Both processes will run on a 8 core server. You can see full details of the instance in this image:
![Server configuration](/img/server_conf.png)


## Assumptions

1. Both processes are running on the same server at same time
2. There's enough free disk to write all the data items.
3. This is not an [ETL](https://en.wikipedia.org/wiki/Extract,_transform,_load), but a continuous flow of data items coming from the producer to the consumer. Therefore, there's no ALL DATA CONSUMED status.

## Approaches
The project will cover different approaches. On every branch under [approaches](branches) you can find the implementation and details of every scenario tested. On every branch you can find also a file called approach.md, that contains all the info related with this case.

For your convenience, here you have a list of the approaches explored.
1. [One file per data item](blob/approaches/ap1/approach.md). [Branch](tree/approaches/ap1)

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