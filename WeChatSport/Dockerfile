FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WeChatSport.csproj", "WeChatSport/"]
RUN dotnet restore "WeChatSport/WeChatSport.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "WeChatSport.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WeChatSport.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WeChatSport.dll"]