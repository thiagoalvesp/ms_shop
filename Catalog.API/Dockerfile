FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Catalog.API/Catalog.API.csproj", "Catalog.API/"]
RUN dotnet restore "Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c release -o /app/build

FROM build as publish
RUN dotnet publish "Catalog.API.csproj" -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Catalog.API.dll"]


