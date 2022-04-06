FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToastyMail/ToastyMail.csproj", "ToastyMail/"]
RUN dotnet restore "ToastyMail/ToastyMail.csproj"
COPY . .
WORKDIR "/src/ToastyMail"
RUN dotnet build "ToastyMail.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToastyMail.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToastyMail.dll"]
