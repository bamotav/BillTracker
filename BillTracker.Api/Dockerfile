FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BillTracker.Api/BillTracker.Api.csproj", "BillTracker.Api/"]
RUN dotnet restore "BillTracker.Api/BillTracker.Api.csproj"
COPY . .
WORKDIR "/src/BillTracker.Api"
RUN dotnet build "BillTracker.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BillTracker.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BillTracker.Api.dll"]