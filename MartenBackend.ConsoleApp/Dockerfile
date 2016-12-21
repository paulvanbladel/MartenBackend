FROM microsoft/dotnet
WORKDIR /MartenBackend.ConsoleApp

# copy project.json and restore as distinct layers
COPY project.json .
RUN dotnet restore

# copy and build everything else
COPY . .
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/MartenBackend.ConsoleApp.dll"]