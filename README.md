# Aprendendo C#

Este projeto foi desenvolvido para aprender C# e praticar conceitos da linguagem por meio de uma aplicação de console. O exercício simula o cadastro e a verificação do status de APIs, com dados armazenados em memória.

## Objetivo de aprendizado

O projeto explora os seguintes conceitos:

- Orientação a objetos: classes, construtores e encapsulamento.
- Interfaces e injeção de dependências pelo construtor.
- Separação de responsabilidades entre entidades, serviços e repositórios.
- Coleções e consultas com LINQ.
- Operações de cadastro, consulta, atualização e exclusão (CRUD).
- Programação assíncrona com `async`, `await`, `Task` e `Task.WhenAll`.
- Uso de enums e tratamento de valores que podem ser nulos.

## Funcionamento

Cada API possui um identificador, um nome e um tempo de resposta em milissegundos. As verificações usam tempos aleatórios e `Task.Delay` para simular respostas, sem realizar chamadas HTTP reais.

O status é definido pelo tempo de resposta:

| Status | Tempo de resposta |
| --- | --- |
| `Healthy` | Até 500 ms |
| `Slow` | Acima de 500 ms e até 1200 ms |
| `Unavailable` | Acima de 1200 ms |

Ao executar, o programa demonstra o cadastro de APIs, a consulta por identificador, verificações individuais e em conjunto, a atualização de um nome, a exclusão de um registro e a listagem dos dados. Os registros existem apenas durante a execução.

## Estrutura

```text
app/
├── Entity/
│   ├── Api.cs
│   └── ApiStatus.cs
├── Repository/
│   ├── IApiRepository.cs
│   └── ApiRepository.cs
└── Service/
    ├── IApiService.cs
    └── ApiService.cs
CSharpExercise.cs
CSharpExercise.csproj
```

- `Entity`: representa as APIs e seus possíveis status.
- `Repository`: define e implementa o armazenamento em memória.
- `Service`: reúne as operações da aplicação e as verificações assíncronas.
- `CSharpExercise.cs`: ponto de entrada com exemplos de uso.

## Como executar

É necessário ter o SDK do .NET 10 instalado. Na pasta raiz do projeto, execute:

```bash
dotnet run
```

Os resultados serão exibidos no terminal. Como os tempos de resposta são aleatórios, os valores e status podem variar entre as execuções.

Este é um projeto de estudo, criado para experimentar e consolidar conhecimentos em C#.
