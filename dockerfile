FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_12.x | bash \
    && apt-get install nodejs -yq
WORKDIR /sources
COPY Directory.Build.props global.json ./
COPY src/Sotsera.Blazor.Toaster/Sotsera.Blazor.Toaster.csproj src/Sotsera.Blazor.Toaster/
COPY samples/ClientSide/ClientSide.csproj samples/ClientSide/
RUN dotnet restore src/Sotsera.Blazor.Toaster/Sotsera.Blazor.Toaster.csproj \
    && dotnet restore samples/ClientSide/ClientSide.csproj
COPY src/Sotsera.Blazor.Toaster src/Sotsera.Blazor.Toaster
COPY samples/ClientSide samples/ClientSide
RUN dotnet build samples/ClientSide/ClientSide.csproj -c Release

FROM build AS publish
RUN dotnet publish "samples/ClientSide/ClientSide.csproj" -c Release -o /publish

FROM fholzer/nginx-brotli AS final
#FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /publish/ClientSide/dist .
COPY --from=publish /publish/wwwroot .
#RUN chmod -R go-rw .
COPY nginx.conf /etc/nginx/nginx.conf