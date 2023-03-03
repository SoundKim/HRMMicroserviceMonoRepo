#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV RecruitingAPIDocker="Data Source=172.29.0.1,1433;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Admin@1234;TrustServerCertificate=True"


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HRM.Recruiting.APILayer/HRM.Recruiting.APILayer.csproj", "HRM.Recruiting.APILayer/"]
RUN dotnet restore "HRM.Recruiting.APILayer/HRM.Recruiting.APILayer.csproj"
COPY . .
WORKDIR "/src/HRM.Recruiting.APILayer"
RUN dotnet build "HRM.Recruiting.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRM.Recruiting.APILayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRM.Recruiting.APILayer.dll"]