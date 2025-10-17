# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivo .csproj y restaurar dependencias
COPY EasyClinic.Server.csproj ./
RUN dotnet restore EasyClinic.Server.csproj

# Copiar el resto del código
COPY . ./

# Publicar en modo Release
RUN dotnet publish EasyClinic.Server.csproj -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Exponer el puerto en el que escucha tu app
EXPOSE 80

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "EasyClinic.Server.dll"]
