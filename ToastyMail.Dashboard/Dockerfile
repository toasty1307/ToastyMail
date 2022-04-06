FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToastyMail.Dashboard/ToastyMail.Dashboard.csproj", "ToastyMail.Dashboard/"]
RUN dotnet restore "ToastyMail.Dashboard/ToastyMail.Dashboard.csproj"
COPY . .
WORKDIR "/src/ToastyMail.Dashboard"
RUN dotnet build "ToastyMail.Dashboard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToastyMail.Dashboard.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToastyMail.Dashboard.dll"]
