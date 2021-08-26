#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/ECommerce.Product.API/ECommerce.Product.API.csproj", "src/Services/ECommerce.Product.API/"]
RUN dotnet restore "src/Services/ECommerce.Product.API/ECommerce.Product.API.csproj"
COPY . .
WORKDIR "/src/src/Services/ECommerce.Product.API"
RUN dotnet build "ECommerce.Product.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Product.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Product.API.dll"]
