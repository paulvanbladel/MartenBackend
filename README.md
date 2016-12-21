
### Why I like the duo Marten - Postgres
First of all, Postgres is a rock solid database and runs on all platforms.
Marten allows, in a core clr .Net app to handover a POCO to the database with no additional ceremony whatsoever. 
That's true elegance. Full Stop :)

###
This project uses preview3 of dotnet core clr 1.1.
Make sure you have installed this sdk.

### how to run from visual studio 2017

press F5.

### How to run from visual studio code

 press F5.

### how to run from command line

#### on windows:
```
set MARTEN_HOST=localhost && set MARTEN_DATABASE=postgres && set MARTEN_USER=postgres && set MARTEN_PASSWORD=. && dotnet run
```
#### on linux:
```
export MARTEN_HOST=localhost && export MARTEN_DATABASE=postgres && export MARTEN_USER=postgres && export MARTEN_PASSWORD=. && dotnet run
```
#### how to run tests from command line
```
set MARTEN_HOST=localhost && set MARTEN_DATABASE=postgres && set MARTEN_USER=postgres && set MARTEN_PASSWORD=. && dotnet test
```

### how to run via docker
on your docker host (e.g. a linux ubuntu machine or VM), from the project folder:

```
sudo docker-compose up
```

