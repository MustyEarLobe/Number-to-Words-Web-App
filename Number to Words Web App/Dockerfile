#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Number to Words Web App/Number to Words Web App.csproj", "Number to Words Web App/"]
RUN dotnet restore "Number to Words Web App/Number to Words Web App.csproj"
COPY . .
WORKDIR "/src/Number to Words Web App"
RUN dotnet build "Number to Words Web App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Number to Words Web App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Number to Words Web App.dll"]