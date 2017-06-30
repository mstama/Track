# Track

Conference Track Management

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/cd3657c3394c4f1e9df995017cdaa600)](https://www.codacy.com/app/marcostamashiro/Track?utm_source=github.com&utm_medium=referral&utm_content=mstama/Track&utm_campaign=badger)
[![Build status](https://ci.appveyor.com/api/projects/status/vkucwbq52709f00y?svg=true)](https://ci.appveyor.com/project/mstama/track)

### How to build

* [Install](https://www.microsoft.com/net/download/core#/current) .NET Core 1.1 
* Restore the packages **(required once)**. In the solution folder, where **Track.sln** is, folder execute the followin command:

```
dotnet restore
```

* In the project folder, where **Track.csproj** is, execute the following command: 

```
dotnet build -c release
```
### How to run

* Running using the project file. In the project folder, where the **Track.csproj** is, execute the following command: 

```
dotnet run input.txt
```

* Running using the binary. Execute the following command with the binary file:

```
dotnet Track.dll input.txt
```
### How to test

* Executing unit tests. In the unit tests project folder, where the **UnitTests.csproj** is, execute the following

```
dotnet test
```

### Architecture

The solution is composed of:

* Models
    * Talk        : Information about a conference talk.
    * Session     : Collection of talks that occurs in the morning or in the afternoon.
    * TrackDay    : Conference day that has a morning and a afternoon session.
* Services
    * Parser      : Responsible for creating talks from the user input.
    * TrackBuilder: Responsible for distributing all the talks in sessions and days.
* Interfaces     : Services are implemented using interfaces to be extensible.

The main program is composed of:

* Composition Root: where all modules are put together.
* Execution of the talk parser.
* Execution of the track builder.

Highlights:
* Extensibility: main modules are provided with an interface so it can be replaced in the composition root for evolution.

[GitHub Project Repository](https://github.com/mstama/Track)