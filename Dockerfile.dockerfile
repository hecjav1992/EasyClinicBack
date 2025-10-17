# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivo .csproj y restaurar dependencias
COPY SistemaDeVisitaCampeon.Server.csproj ./
RUN dotnet restore SistemaDeVisitaCampeon.Server.csproj

# Copiar el resto del código
COPY . ./

# Publicar en modo Release
RUN dotnet publish SistemaDeVisitaCampeon.Server.csproj -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Exponer el puerto en el que escucha tu app
EXPOSE 80

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "EasyClinic.Server.dll"]
