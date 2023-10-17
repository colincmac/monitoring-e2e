#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppFailures.Web/AppFailures.Web.csproj", "AppFailures.Web/"]
RUN dotnet restore "AppFailures.Web/AppFailures.Web.csproj"
COPY . .
WORKDIR "/src/AppFailures.Web"
RUN dotnet build "AppFailures.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppFailures.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppFailures.Web.dll"]