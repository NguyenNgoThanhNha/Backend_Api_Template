FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY Directory.Build.props ServerApiTemplate.sln ./
COPY src/ServerApiTemplate.Domain/ServerApiTemplate.Domain.csproj src/ServerApiTemplate.Domain/
COPY src/ServerApiTemplate.Persistence/ServerApiTemplate.Persistence.csproj src/ServerApiTemplate.Persistence/
COPY src/ServerApiTemplate.Application/ServerApiTemplate.Application.csproj src/ServerApiTemplate.Application/
COPY src/ServerApiTemplate.Infrastructure/ServerApiTemplate.Infrastructure.csproj src/ServerApiTemplate.Infrastructure/
COPY src/ServerApiTemplate.Api/ServerApiTemplate.Api.csproj src/ServerApiTemplate.Api/
RUN dotnet restore src/ServerApiTemplate.Api/ServerApiTemplate.Api.csproj
COPY src/ src/
RUN dotnet publish src/ServerApiTemplate.Api/ServerApiTemplate.Api.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "ServerApiTemplate.Api.dll"]
