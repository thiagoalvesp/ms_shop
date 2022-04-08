FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Discount.API/Discount.API.csproj", "Discount.API/"]
RUN dotnet restore "Discount.API/Discount.API.csproj"
COPY . .
WORKDIR "/src/Discount.API"
RUN dotnet build "Discount.API.csproj" -c release -o /app/build

FROM build as publish
RUN dotnet publish "Discount.API.csproj" -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Discount.API.dll"]


