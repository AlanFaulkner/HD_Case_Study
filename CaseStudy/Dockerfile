FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1803 AS build
WORKDIR /src
COPY ["CaseStudy/CaseStudy.csproj", "CaseStudy/"]
RUN dotnet restore "CaseStudy/CaseStudy.csproj"
COPY . .
WORKDIR "/src/CaseStudy"
RUN dotnet build "CaseStudy.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CaseStudy.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CaseStudy.dll"]