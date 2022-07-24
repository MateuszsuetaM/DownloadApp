FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /source/
RUN dotnet publish -c release -o / #--no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /
#RUN mkdir Resources
VOLUME ["/Files"]
COPY --from=build / ./
ENTRYPOINT ["dotnet", "DownloadApp.dll"]