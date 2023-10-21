#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["muchik.market.api.gateway.csproj", "muchik.market.api.gateway/"]
RUN dotnet restore "muchik.market.api.gateway/muchik.market.api.gateway.csproj"
COPY . .
WORKDIR "/src/muchik.market.api.gateway"
RUN dotnet build "muchik.market.api.gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "muchik.market.api.gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV Cloud__Config__Uri=http://localhost:8888;


ENTRYPOINT ["dotnet", "muchik.market.api.gateway.dll"]
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#
#COPY ./publish/ /app
#ENV ASPNETCORE_URL = http://+:8080
#ENV ASPNETCORE_ENVIRONMENT docker
#ENV Cloud__Config__Uri=http://muchik-config:8888;
#EXPOSE 80
#
#ENTRYPOINT ["dotnet","/app/muchik.market.api.gateway.dll"]