# build "server" image
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

WORKDIR /src

COPY FullStackDevOps.slnx .
COPY FullStackDevOps.AppHost/FullStackDevOps.AppHost.csproj FullStackDevOps.AppHost/.
COPY FullStackDevOps.Server/FullStackDevOps.Server.csproj FullStackDevOps.Server/.
RUN dotnet restore FullStackDevOps.slnx

COPY . .
RUN dotnet build -c Release FullStackDevOps.slnx
RUN dotnet test -c Release --no-build FullStackDevOps.slnx
RUN dotnet publish --no-build -c Release -o /dist FullStackDevOps.Server/FullStackDevOps.Server.csproj


# production runtime "server" image
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__DefaultConnection=""

WORKDIR /app
COPY --from=build /dist .
CMD ["dotnet", "FullStackDevOps.Server.dll"]
