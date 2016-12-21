FROM microsoft/dotnet:1.1.0-sdk-msbuild


# copy project.json and restore as distinct layers
#COPY MartenBackend.ConsoleApp.csproj .

# copy and build everything else
COPY . .
RUN dotnet restore

RUN dotnet publish ./MartenBackend.ConsoleApp/MartenBackend.ConsoleApp.csproj -c Release -o out
ENTRYPOINT ["dotnet", "./MartenBackend.ConsoleApp/out/MartenBackend.ConsoleApp.dll"]