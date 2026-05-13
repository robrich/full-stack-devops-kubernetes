# build "server" image
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

WORKDIR /src

COPY FullStackDevOps.slnx .
COPY FullStackDevOps.Server/FullStackDevOps.Server.csproj FullStackDevOps.Server/FullStackDevOps.Server.csproj
COPY FullStackDevOps.Client/FullStackDevOps.Client.csproj FullStackDevOps.AppHost/FullStackDevOps.AppHost.csproj
RUN dotnet restore FullStackDevOps.slnx

COPY . .
RUN dotnet build -c Release FullStackDevOps.slnx
RUN dotnet test -c Release FullStackDevOps.slnx
RUN dotnet publish -c Release -o /dist FullStackDevOps.Server/FullStackDevOps.Server.csproj

# Production runtime "server" image
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__MyDB=""

WORKDIR /app
COPY --from=build /dist .
CMD ["dotnet", "FullStackDevOps.Server.dll"]
