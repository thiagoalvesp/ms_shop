FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Discount.GRPC/Discount.GRPC.csproj", "Discount.GRPC/"]
RUN dotnet restore "Discount.GRPC/Discount.GRPC.csproj"
COPY . .
WORKDIR "/src/Discount.GRPC"
RUN dotnet build "Discount.GRPC.csproj" -c release -o /app/build

FROM build as publish
RUN dotnet publish "Discount.GRPC.csproj" -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Discount.GRPC.dll"]


