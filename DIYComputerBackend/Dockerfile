FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DIYComputerBackend/DIYComputerBackend.csproj", "DIYComputerBackend/"]
RUN dotnet restore "DIYComputerBackend/DIYComputerBackend.csproj"
COPY . .
WORKDIR "/src/DIYComputerBackend"
RUN dotnet build "DIYComputerBackend.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DIYComputerBackend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DIYComputerBackend.dll"]