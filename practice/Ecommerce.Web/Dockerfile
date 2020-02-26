FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Ecommerce.Web/*.csproj", "Ecommerce.Web/"]
COPY ["Ecommerce.Core/*.csproj", "Ecommerce.Core/"]
COPY ["Ecommerce.Data/*.csproj", "Ecommerce.Data/"]
RUN dotnet restore "Ecommerce.Web/Ecommerce.Web.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Web"
RUN dotnet build "Ecommerce.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ecommerce.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ecommerce.Web.dll"]