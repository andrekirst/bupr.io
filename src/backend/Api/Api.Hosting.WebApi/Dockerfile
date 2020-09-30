#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Api.Hosting.WebApi/Api.Hosting.WebApi.csproj", "Api.Hosting.WebApi/"]
RUN dotnet restore "Api.Hosting.WebApi/Api.Hosting.WebApi.csproj"
COPY . .
WORKDIR "/src/Api.Hosting.WebApi"
RUN dotnet build "Api.Hosting.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Hosting.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Hosting.WebApi.dll"]