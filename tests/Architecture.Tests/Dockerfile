#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["tests/Architecture.Tests/Architecture.Tests.csproj", "tests/Architecture.Tests/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Client/Client.csproj", "src/Client/"]
COPY ["src/Domain.Shared/Domain.Shared.csproj", "src/Domain.Shared/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Persistence/Persistence.csproj", "src/Persistence/"]
COPY ["src/Server.Contracts/Server.Contracts.csproj", "src/Server.Contracts/"]
COPY ["src/Server/Server.csproj", "src/Server/"]
RUN dotnet restore "tests/Architecture.Tests/Architecture.Tests.csproj"
COPY . .
WORKDIR "/src/tests/Architecture.Tests"
RUN dotnet build "Architecture.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Architecture.Tests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Architecture.Tests.dll"]