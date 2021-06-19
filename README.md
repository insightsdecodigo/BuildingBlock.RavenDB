# BuildingBlock.RavenDB 
Componente em dotnet 6 para abstrair a maneira de como utilizar NoSQL Document Database em suas aplicações.

## Tecnologias utilizadas :rocket:

| Nome   | Descrição                  |
| ---------- |  --------------------- |
| RavenDB  | NoSQL Document Database |
| Class libery | Criada com .NET 6    |


## Índice :pencil:

* [Instalação](#instalação)
* [Como usar](#como-usar)
* [Demo](#application-demo-configs)

## Instalação
> Realize a criação de conta no cloud `RavenDB` e, faça as configurações necessárias para que suba o servidor.

| Nome   | Descrição                    | Obrigátorio               |
| ---------- | ------------------------------ | --------------------- |
| 🌎[RavenDB](https://ravendb.net/)       |     Requisito necessário para o criar o database.            |:white_check_mark: |

## Como usar
> Após realizar as configurações do `RavenDB` e já com o `servidor` em pé crie uma tabela com o nome que você irá configurar logo depois na demo.

### Criar registro no RavenDB
```
void Create(object obj);
```
### Listar todos registros de uma tabela
```
List<T> LoadQuerying<T>(string Name) where T : class, new();
```

## Application Demo Configs
> No arquivo `appsettings.json`, você deve colocar as configurações que você fez nos passos anteriores.
```
{
  "RAVENDB_INSTANCE_NAME": "Nome da base de dados",
  "RAVENDB_CONFIGURATION_URL": "url de conection string",
  "RAVENDB_MAX_NUMBER_OF_REQUESTS_PER_SESSION": "100",
  "RAVENDB_OPTIMISTIC_CONCURRENCY": "true",
  "RAVENDB_COLLECTIONNAME": "Objeto",
  "RAVENDB_PATH_CERTIFICATE": "C:\\ravendb.certificate\\certificate.pfx"
}
```
### 1. Demo:
> Console application `PocRavenDB`.

### 2. Testes unitários:
> NUnit application `BuildingBlock.RavenDB.Tests`.