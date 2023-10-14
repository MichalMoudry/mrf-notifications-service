FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# Restore project and solution
COPY *.sln .
COPY NotificationsService/*.csproj ./NotificationsService/
RUN dotnet restore

# Copy source code and build the app
COPY NotificationsService/. ./NotificationsService/
WORKDIR /source/NotificationsService
RUN dotnet publish -c release -o /app --no-restore

# Create release image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
ENTRYPOINT [ "dotnet", "NotificationsService.dll" ]