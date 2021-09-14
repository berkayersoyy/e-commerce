#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Ordering/ECommerce.Ordering.API/ECommerce.Ordering.API.csproj", "src/Services/Ordering/ECommerce.Ordering.API/"]
COPY ["src/Services/Common/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/Services/Common/EventBusRabbitMQ/"]
COPY ["src/Services/Ordering/ECommerce.Ordering.Infrastructure/ECommerce.Ordering.Infrastructure.csproj", "src/Services/Ordering/ECommerce.Ordering.Infrastructure/"]
COPY ["src/Services/Ordering/ECommerce.Ordering.Domain/ECommerce.Ordering.Domain.csproj", "src/Services/Ordering/ECommerce.Ordering.Domain/"]
COPY ["src/Services/Ordering/ECommerce.Ordering.Application/ECommerce.Ordering.Application.csproj", "src/Services/Ordering/ECommerce.Ordering.Application/"]
RUN dotnet restore "src/Services/Ordering/ECommerce.Ordering.API/ECommerce.Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Ordering/ECommerce.Ordering.API"
RUN dotnet build "ECommerce.Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Ordering.API.dll"]
