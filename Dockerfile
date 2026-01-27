# Imagem oficial .NET SDK 10 baseada em Debian
FROM mcr.microsoft.com/dotnet/sdk:10.0

# Variáveis de ambiente
ENV DOTNET_USE_POLLING_FILE_WATCHER=1 \
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_NOLOGO=true \
    NUGET_XMLDOC_MODE=skip \
    NODE_VERSION=24.13.0

# Instala Node.js e Angular CLI
RUN apt-get update && apt-get install -y curl xz-utils build-essential \
    && curl -fsSL https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.xz -o node.tar.xz \
    && mkdir -p /usr/local/lib/nodejs \
    && tar -xJf node.tar.xz -C /usr/local/lib/nodejs \
    && rm node.tar.xz \
    && ln -s /usr/local/lib/nodejs/node-v${NODE_VERSION}-linux-x64/bin/node /usr/local/bin/node \
    && ln -s /usr/local/lib/nodejs/node-v${NODE_VERSION}-linux-x64/bin/npm /usr/local/bin/npm \
    && npm install -g @angular/cli@21

# Diretório de trabalho
WORKDIR /app

# Copia o projeto (opcional)
COPY ./ ./ 

# Restaura pacotes .NET
RUN dotnet restore

# Expõe portas
EXPOSE 5091 4200

# Comando default: backend .NET com hot reload
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5091"]
