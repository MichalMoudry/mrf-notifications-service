FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NotificationService.TaskService/NotificationService.TaskService.fsproj", "NotificationService.TaskService/"]
RUN dotnet restore "NotificationService.TaskService/NotificationService.TaskService.fsproj"
COPY . .
WORKDIR "/src/NotificationService.TaskService"
RUN dotnet build "NotificationService.TaskService.fsproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NotificationService.TaskService.fsproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationService.TaskService.dll"]
