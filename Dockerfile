# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ENV ASPNETCORE_ENVIRONMENT=Development

# Definir o diretório de trabalho
WORKDIR /src

# Copiar os arquivos de projeto para o diretório de build
COPY src/SampleCleanArchProject.Api/SampleCleanArchProject.Api/SampleCleanArchProject.Api.csproj ./SampleCleanArchProject.Api/
COPY src/SampleCleanArchProject.Application/SampleCleanArchProject.Application/SampleCleanArchProject.Application.csproj ./SampleCleanArchProject.Application/
COPY src/SampleCleanArchProject.Domain/SampleCleanArchProject.Domain/SampleCleanArchProject.Domain.csproj ./SampleCleanArchProject.Domain/
COPY src/SampleCleanArchProject.Infra.Data/SampleCleanArchProject.Infra.Data/SampleCleanArchProject.Infra.Data.csproj ./SampleCleanArchProject.Infra.Data/
COPY src/SampleCleanArchProject.Infra.IoC/SampleCleanArchProject.Infra.IoC/SampleCleanArchProject.Infra.IoC.csproj ./SampleCleanArchProject.Infra.IoC/

RUN ls -R /src

# Restaurar as dependências com base no arquivo .csproj ou .sln
RUN dotnet restore ./SampleCleanArchProject.Api/SampleCleanArchProject.Api.csproj


# Copiar o restante dos arquivos e compilar
COPY . .
RUN dotnet publish src/SampleCleanArchProject.Api/SampleCleanArchProject.Api/SampleCleanArchProject.Api.csproj -c Release -o /app/publish

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

# Copiar o aplicativo publicado para a imagem final
COPY --from=build /app/publish .

# Expor a porta 80
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "SampleCleanArchProject.Api.dll"]
