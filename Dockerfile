FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-api
WORKDIR /app

EXPOSE 80

COPY DocumentService/*.csproj ./DocumentService/

WORKDIR /app/DocumentService
RUN dotnet restore

WORKDIR /app
COPY DocumentService/ ./DocumentService/

WORKDIR /app/DocumentService
RUN dotnet publish /property:PublishWithAspNetCoreTargetManifest=false -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app

COPY --from=build-api /app/DocumentService/out ./
ENTRYPOINT ["dotnet", "DocumentService.dll"]