FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FeatureFlagApi/FeatureFlagApi.csproj", "FeatureFlagApi/"]
RUN dotnet restore "FeatureFlagApi/FeatureFlagApi.csproj"
COPY . .
WORKDIR "/src/FeatureFlagApi"
RUN dotnet build "FeatureFlagApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeatureFlagApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeatureFlagApi.dll"]
