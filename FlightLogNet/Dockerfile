FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY ./bin/Release/net8.0/linux-musl-x64/publish ./
EXPOSE 80
ENTRYPOINT ["dotnet", "./FlightLogNet.dll"]