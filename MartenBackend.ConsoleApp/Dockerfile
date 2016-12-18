FROM microsoft/dotnet
WORKDIR /MartenTrialCoreClr

# copy project.json and restore as distinct layers
COPY project.json .
RUN dotnet restore

# copy and build everything else
COPY . .
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/MartenTrialCoreClr.dll"]