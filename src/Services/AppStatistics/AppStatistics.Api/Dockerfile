FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/AppStatistics/AppStatistics.Api/AppStatistics.Api.csproj", "Services/AppStatistics/AppStatistics.Api/"]
COPY ["Services/AppStatistics/AppStatistics.BusinessLayer/AppStatistics.BusinessLayer.csproj", "Services/AppStatistics/AppStatistics.BusinessLayer/"]
COPY ["Libs/Responses/Responses.csproj", "Libs/Responses/"]
COPY ["Services/EventBus/EventBus.csproj", "Services/EventBus/"]
COPY ["Services/AppStatistics/AppStatistics.DomainLayer/AppStatistics.DomainLayer.csproj", "Services/AppStatistics/AppStatistics.DomainLayer/"]
RUN dotnet restore "Services/AppStatistics/AppStatistics.Api/AppStatistics.Api.csproj"
COPY . .
WORKDIR "/src/Services/AppStatistics/AppStatistics.Api"
RUN dotnet build "AppStatistics.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppStatistics.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppStatistics.Api.dll"]