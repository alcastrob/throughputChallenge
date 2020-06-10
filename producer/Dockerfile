#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
COPY . .
WORKDIR /app/src/
RUN dotnet restore ./producer.csproj
RUN dotnet build ./producer.csproj -c Release -o /app/build

FROM build AS publish
WORKDIR /app/src/
RUN dotnet publish ./producer.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "producer.dll"]