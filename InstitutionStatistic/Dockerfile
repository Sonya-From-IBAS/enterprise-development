FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ["InstitutionStatistic.WebApi/InstitutionStatistic.WebApi.csproj", "InstitutionStatistic.WebApi/"]
COPY ["InstitutionStatistic.Domain/InstitutionStatistic.Domain.csproj", "InstitutionStatistic.Domain/"]
RUN dotnet restore "InstitutionStatistic.WebApi/InstitutionStatistic.WebApi.csproj"

COPY . ./

WORKDIR "/app/InstitutionStatistic.WebApi"
RUN dotnet build "./InstitutionStatistic.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./InstitutionStatistic.WebApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstitutionStatistic.WebApi.dll"]
