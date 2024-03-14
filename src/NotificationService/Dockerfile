FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NotificationService/NotificationService.fsproj", "NotificationService/"]
RUN dotnet restore "NotificationService/NotificationService.fsproj"
COPY . .
WORKDIR "/src/NotificationService"
RUN dotnet build "NotificationService.fsproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NotificationService.fsproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
USER $APP_UID
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "NotificationService.dll"]
