FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Hid.Checkpoint.Api/Hid.Checkpoint.Api.csproj", "src/Hid.Checkpoint.Api/"]
RUN dotnet restore "src/Hid.Checkpoint.Api/Hid.Checkpoint.Api.csproj"
COPY . .
WORKDIR "/src/src/Hid.Checkpoint.Api"
RUN dotnet build "Hid.Checkpoint.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hid.Checkpoint.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hid.Checkpoint.Api.dll"]
