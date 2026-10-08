# Basic Architecture

A minimal example of structuring a solution so that the **product** (the business logic) is separate from the applications that **consume** it.

## Projects

| Project | Role |
| --- | --- |
| `Example.Product` | The product: business logic and data access. It has no knowledge of how it is consumed. |
| `Example.Api` | A minimal API that exposes the product over HTTP. |
| `Example.Cli` | A command line application that exposes the product in a terminal. |

`Example.Api` and `Example.Cli` both reference `Example.Product`. `Example.Product` references neither.

## Running

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

**API**

```sh
dotnet run --project src/Example.Api
```

Then use the requests in [`Example.Api.http`](src/Example.Api/Example.Api.http).

**CLI**

```sh
dotnet run --project src/Example.Cli -- list-todos
dotnet run --project src/Example.Cli -- get-todo --id 00000000-0000-0000-891c-000000000001
dotnet run --project src/Example.Cli -- add-todo --title "Title" --description "Description"
```

## Deliberate simplifications

- The repository is in-memory and seeded with sample data, so CLI changes don't persist between runs. In a real-world scenario it would use a datastore.
- Neither the API nor the CLI is authenticated.
- The API and CLI are consumed differently, so they don't behave identically (for example, an empty list is `204 No Content` from the API but `[]` from the CLI).
