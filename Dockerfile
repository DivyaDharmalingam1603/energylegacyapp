# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything (solution and all projects)
COPY . .

# Restore dependencies (using the solution file is better here)
RUN dotnet restore ./EnergyLegacyApp.sln

# Build and publish the app
#Testing
RUN dotnet publish ./EnergyLegacyApp.Business/EnergyLegacyApp.Business.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "EnergyLegacyApp.Business.dll"]
