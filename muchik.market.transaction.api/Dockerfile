#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["muchik.market.transaction.api/muchik.market.transaction.api.csproj", "muchik.market.transaction.api/"]
#COPY ["muchik.market.transaction.application/muchik.market.transaction.application.csproj", "muchik.market.transaction.application/"]
#COPY ["Muchik.Market.Domain/muchik.market.domain.csproj", "Muchik.Market.Domain/"]
#COPY ["muchik.market.transaction.domain/muchik.market.transaction.domain.csproj", "muchik.market.transaction.domain/"]
#COPY ["muchik.market.transaction.infraestructure/muchik.market.transaction.infraestructure.csproj", "muchik.market.transaction.infraestructure/"]
#RUN dotnet restore "muchik.market.transaction.api/muchik.market.transaction.api.csproj"
#COPY . .
#WORKDIR "/src/muchik.market.transaction.api"
#RUN dotnet build "muchik.market.transaction.api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "muchik.market.transaction.api.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "muchik.market.transaction.api.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY ./publish/ /app
ENV ASPNETCORE_URL = http://+:8080
ENV ASPNETCORE_ENVIRONMENT dev
ENV Cloud__Config__Uri=http://muchik-config:8888;
EXPOSE 80

ENTRYPOINT ["dotnet","/app/muchik.market.transaction.api.dll"]