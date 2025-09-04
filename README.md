# 🎠 ToyBarn API

API RESTful para gerenciamento de brinquedos infantis (até 14 anos), desenvolvida em **ASP.NET Core** utilizando **Entity Framework Core** e banco de dados relacional **SQLite**.  

O projeto contempla todas as operações de **CRUD (Create, Read, Update, Delete)**, com documentação interativa via **Swagger** e possibilidade de testes via **Postman**.

---

## 📋 Funcionalidades

- ✅ **GET** `/api/brinquedos` → Lista todos os brinquedos  
- ✅ **GET** `/api/brinquedos/{id}` → Busca brinquedo pelo ID  
- ✅ **POST** `/api/brinquedos` → Cria novo brinquedo  
- ✅ **PUT** `/api/brinquedos/{id}` → Atualiza um brinquedo existente  
- ✅ **DELETE** `/api/brinquedos/{id}` → Remove um brinquedo  

---

## 🧩 Estrutura da entidade `Brinquedo`

```csharp
public class Brinquedo {
    public int Id_brinquedo { get; set; }
    public string Nome_brinquedo { get; set; } = string.Empty;
    public string Tipo_brinquedo { get; set; } = string.Empty;
    public string Classificacao { get; set; } = string.Empty;
    public string Tamanho { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
🛠️ Tecnologias
⚙️ ASP.NET Core Web API

🗄️ Entity Framework Core

💾 Banco de dados SQLite

📑 Swagger

🔬 Postman

▶️ Como rodar o projeto
🔹 Pré-requisitos
.NET 7 SDK (ou superior)

Banco de dados configurado

EF Core Tools (opcional, mas recomendado)

🔹 Passos
Clone o repositório:

bash
Copiar código
git clone https://github.com/hellomesq/ToyBarn.git
cd ToyBarn
Configure a connection string no arquivo appsettings.json:

json
Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=toybarn.db"
  }
}
Crie o banco e aplique as migrations:

bash
Copiar código
dotnet ef migrations add InitialCreate
dotnet ef database update
Execute a aplicação:

bash
Copiar código
dotnet run
Acesse a documentação Swagger:

bash
Copiar código
http://localhost:5220/swagger/index.html
📌 Exemplos de uso no Postman
🔹 Listar todos os brinquedos (GET)
http
Copiar código
GET {{baseUrl}}/api/brinquedos
🔹 Buscar brinquedo por ID (GET)
http
Copiar código
GET {{baseUrl}}/api/brinquedos/1
🔹 Cadastrar novo brinquedo (POST)
URL

http
Copiar código
POST {{baseUrl}}/api/brinquedos
Body (raw / JSON)

json
Copiar código
{
  "nome_brinquedo": "Carrinho Hot Wheels",
  "tipo_brinquedo": "Carrinho",
  "classificacao": "5+",
  "tamanho": "Pequeno",
  "preco": 29.90
}
🔹 Atualizar brinquedo existente (PUT)
URL

http
Copiar código
PUT {{baseUrl}}/api/brinquedos/1
Body (raw / JSON)

json
Copiar código
{
  "id_brinquedo": 1,
  "nome_brinquedo": "Boneca Barbie",
  "tipo_brinquedo": "Boneca",
  "classificacao": "7+",
  "tamanho": "Médio",
  "preco": 99.90
}
🔹 Remover brinquedo (DELETE)
http
Copiar código
DELETE {{baseUrl}}/api/brinquedos/1
Onde está {{baseUrl}}, configure no Postman de acordo com sua aplicação, por exemplo:

https://localhost:5001

ou http://localhost:5038

🖼️ Testes no Swagger e Postman
📄 GET – Listar todos os brinquedos → Retorna a lista completa

🔍 GET – Buscar por ID → Retorna brinquedo específico

➕ POST – Criar novo brinquedo → Insere um novo registro

🔄 PUT – Atualizar brinquedo → Atualiza os dados existentes

❌ DELETE – Remover brinquedo → Exclui pelo ID informado

📊 Arquitetura do Sistema
java
Copiar código
Swagger/Postman (CRUD JSON)
        ⬇
 API ASP.NET Core (Controllers + EF Core)
        ⬇
   Banco de Dados SQLite
yaml
Copiar código
