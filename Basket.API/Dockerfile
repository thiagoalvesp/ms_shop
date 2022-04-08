FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Basket.API/Basket.API.csproj", "Basket.API/"]
RUN dotnet restore "Basket.API/Basket.API.csproj"
COPY . .
WORKDIR "/src/Basket.API"
RUN dotnet build "Basket.API.csproj" -c release -o /app/build

FROM build as publish
RUN dotnet publish "Basket.API.csproj" -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Basket.API.dll"]


