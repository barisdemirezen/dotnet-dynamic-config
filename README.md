# Dotnet Dynamic Config 🎉

Dotnet Dynamic Config is a handy project that helps to create dynamic configuration in .net core projects.

## About it 📝

Dotnet Dynamic Config allows developers to make configuration changes without re-deploying or restarting running .net core projects.

It uses Sql Server as persistent store and Redis pub/sub to communicate with consumer projects.

**Publisher Project** shows existing keys/values and can modify existing values
**Subscriber Project** shows a demo endpoint to check if system works.

## Install, run, dev 🏗️

First you have to build your database and table. Run the PreRequisites/Database.sql file on your Sql Server.

Make sure you have a Redis running.

```
BLA BLA BLA
```

## API Usage ✨

#### Shows all products with or without filters

```
  GET /api/product
  GET /api/product?{price=asc||desc}&{category=categoryName}&{q=searchTitle}
```

| Parameter  | Type            | Description                                             |
| ---------- | --------------- | ------------------------------------------------------- |
| `price`    | `asc` or `desc` | Orders products by price ascending or descending.       |
| `category` | `string`        | Filters categories by given category name               |
| `q`        | `string`        | Filters products by title that includes given parameter |

#### Shows product with given id

```
  GET /api/product/${id}
```

| Parameter | Type     | Description                 |
| --------- | -------- | --------------------------- |
| `id`      | `number` | **Required**. Id of product |

#### Simulates adding product to database. Returns a product with new Id.

```
  POST /api/product/
```

| Parameter     | Type     | Description            |
| ------------- | -------- | ---------------------- |
| `title`       | `string` | Title of product       |
| `description` | `string` | Description of product |
| `image`       | `string` | Image url of product   |
| `price`       | `number` | Price of product       |
| `category`    | `string` | Category of product    |

#### Simulates updating product. Returns product with updated data.

```
  PUT /api/product/${id}
```

| Parameter     | Type     | Description                 |
| ------------- | -------- | --------------------------- |
| `id`          | `number` | **Required**. Id of product |
| `title`       | `string` | Title of product            |
| `description` | `string` | Description of product      |
| `image`       | `string` | Image url of product        |
| `price`       | `number` | Price of product            |
| `category`    | `string` | Category of product         |

```
 DELETE /api/product/${id}
```

| Parameter | Type     | Description                 |
| --------- | -------- | --------------------------- |
| `id`      | `number` | **Required**. Id of product |

## Tech Stack 🔥

**Languages:** .NET 6

**Client:** .NET 6 MVC with Bootstrap

**Server:** .NET 6 WEBAPI

**Data Store:** Sql Server, Redis

## Badges 📌

[![img](https://img.shields.io/github/last-commit/barisdemirezen/dotnet-dynamic-config/main?style=flat-square)](https://img.shields.io/github/last-commit/barisdemirezen/dotnet-dynamic-config/main?style=flat-square)
