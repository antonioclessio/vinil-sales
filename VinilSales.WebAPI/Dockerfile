FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["VinilSales.WebAPI/VinilSales.WebAPI.csproj", "VinilSales.WebAPI/"]
RUN dotnet restore "VinilSales.WebAPI/VinilSales.WebAPI.csproj"
COPY . .
WORKDIR "/src/VinilSales.WebAPI"
RUN dotnet build "VinilSales.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VinilSales.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VinilSales.WebAPI.dll"]