#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ApiGateway/ECommerce.APIGateway/ECommerce.APIGateway.csproj", "src/ApiGateway/ECommerce.APIGateway/"]
RUN dotnet restore "src/ApiGateway/ECommerce.APIGateway/ECommerce.APIGateway.csproj"
COPY . .
WORKDIR "/src/src/ApiGateway/ECommerce.APIGateway"
RUN dotnet build "ECommerce.APIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.APIGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.APIGateway.dll"]
