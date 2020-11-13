FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80 443
# EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EComm.Web.csproj", "."]
RUN dotnet restore "EComm.Web.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "EComm.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EComm.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EComm.Web.dll"]