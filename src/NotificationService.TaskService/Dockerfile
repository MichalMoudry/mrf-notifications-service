FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
RUN apt update
RUN apt install -y clang zlib1g-dev

COPY ["NotificationService.TaskService/", "NotificationService.TaskService/"]
COPY ["NotificationService.Database/", "NotificationService.Database/"]

RUN dotnet restore "NotificationService.TaskService/NotificationService.TaskService.fsproj"
WORKDIR "/src/NotificationService.TaskService"
RUN dotnet publish "NotificationService.TaskService.fsproj" \
    -c $BUILD_CONFIGURATION \
    --os linux \
    --arch x64 \
    -o /src/build

FROM mcr.microsoft.com/dotnet/runtime:8.0-jammy-chiseled AS release
WORKDIR /app

COPY --from=build-env /src/build .

ENTRYPOINT ["/app/NotificationService.TaskService"]
