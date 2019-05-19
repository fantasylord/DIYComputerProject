FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DIYComputer.WebFrontend/DIYComputer.WebFrontend.csproj", "DIYComputer.WebFrontend/"]
RUN dotnet restore "DIYComputer.WebFrontend/DIYComputer.WebFrontend.csproj"
COPY . .
WORKDIR "/src/DIYComputer.WebFrontend"
RUN dotnet build "DIYComputer.WebFrontend.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DIYComputer.WebFrontend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DIYComputer.WebFrontend.dll"]