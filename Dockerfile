FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY src/ .

WORKDIR /app/Cashflow.Api

RUN dotnet restore

RUN dotnet publish -c Release -o /app/out

FROM cr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]