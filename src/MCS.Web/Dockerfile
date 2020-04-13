FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MCS.Web/MCS.Web.csproj", "MCS.Web/"]
RUN dotnet restore "MCS.Web/MCS.Web.csproj"
COPY . .
WORKDIR "/src/MCS.Web"
RUN dotnet build "MCS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MCS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MCS.Web.dll"]