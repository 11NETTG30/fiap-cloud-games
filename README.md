# fiap-cloud-games

## 🚀 Setup Inicial

### 1. Configurar Variáveis de Ambiente do docker-compose

```bash
# Copie o arquivo de exemplo
cp .env.example .env

# Edite o .env com suas credenciais
```

### 2. Configurar Variáveis de Ambiente do projeto (src\FCG.API)

```bash
# Copie o arquivo de exemplo
cp .env.example .env

# Edite o .env com suas credenciais
```

### 3. Comandos Docker / Banco de Dados

```bash
# Inicia PostgreSQL e PgAdmin (obs: necessário instalar e abrir o Docker Desktop)
docker-compose up -d

# Verifica se subiu
docker-compose ps

# Ver logs
docker-compose logs -f postgres

# Parar
docker-compose down

# Parar e remover volumes (cuidado: apaga os dados!)
docker-compose down -v

# Acessar o PostgreSQL
docker exec -it fcg-postgres psql -U fcgadmin -d fcg_plataforma_jogos

# Caso dê erro para subir o container postgres, rode o seguinte comando no terminal:
wsl dos2unix scripts/init-database.sh
```

### 4. Aplicar Migrations

No console do Gerenciador de Pacotes, selecione o projeto padrão (ex: `Services\Pedido\FCG.Pedido.Infrastructure`) e execute os comandos:

```powershell
# Criar uma nova migration
Add-Migration MigrationInicialPedidos -Context PedidoDbContext
# Aplicar as alterações no banco de dados
Update-Database
```

### 5. Execução inicial da Aplicação

```bash
# Para iniciar o banco de dados, no PowerShell
docker-compose up -d

# Aplicar as alterações no banco de dados, no Console do Gerenciador de Pacotes
Update-Database
```

Rodar a API (FCG.API)

Acesse: https://localhost:5001/swagger

## Dados do administrador para login:
"email": "admin@fcg.com.br",
"senha": "Admin@123"

## 📊 Acessar PgAdmin

- **URL:** http://localhost:5050
- **Email:** (veja `.env` - `PGADMIN_DEFAULT_EMAIL`)
- **Senha:** (veja `.env` - `PGADMIN_DEFAULT_PASSWORD`)

### Configurar Conexão no PgAdmin

- **Host:** `postgres`
- **Port:** `5432`
- **Database:** (veja `.env` - `POSTGRES_DB`)
- **Username:** (veja `.env` - `POSTGRES_USER`)
- **Password:** (veja `.env` - `POSTGRES_PASSWORD`)