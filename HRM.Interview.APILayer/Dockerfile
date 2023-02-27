#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HRM.Interview.APILayer/HRM.Interview.APILayer.csproj", "HRM.Interview.APILayer/"]
RUN dotnet restore "HRM.Interview.APILayer/HRM.Interview.APILayer.csproj"
COPY . .
WORKDIR "/src/HRM.Interview.APILayer"
RUN dotnet build "HRM.Interview.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRM.Interview.APILayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRM.Interview.APILayer.dll"]