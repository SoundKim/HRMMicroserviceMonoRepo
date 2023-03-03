#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV AuthenticationAPIDocker="Data Source=172.29.0.1,1433;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Admin@1234;TrustServerCertificate=True"


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HRM.Authentication.APILayer/HRM.Authentication.APILayer.csproj", "HRM.Authentication.APILayer/"]
COPY ["HRM.Authentication.Infrastructure/HRM.Authentication.Infrastructure.csproj", "HRM.Authentication.Infrastructure/"]
COPY ["HRM.Authentication.ApplicationCore/HRM.Authentication.ApplicationCore.csproj", "HRM.Authentication.ApplicationCore/"]
RUN dotnet restore "HRM.Authentication.APILayer/HRM.Authentication.APILayer.csproj"
COPY . .
WORKDIR "/src/HRM.Authentication.APILayer"
RUN dotnet build "HRM.Authentication.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRM.Authentication.APILayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRM.Authentication.APILayer.dll"]