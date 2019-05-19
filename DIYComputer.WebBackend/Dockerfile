FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DIYComputer.WebBackend/DIYComputer.WebBackend.csproj", "DIYComputer.WebBackend/"]
RUN dotnet restore "DIYComputer.WebBackend/DIYComputer.WebBackend.csproj"
COPY . .
WORKDIR "/src/DIYComputer.WebBackend"
RUN dotnet build "DIYComputer.WebBackend.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DIYComputer.WebBackend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DIYComputer.WebBackend.dll"]