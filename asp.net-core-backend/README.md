--- template made with https://readme.so/editor ---


# ASP.NET Core Web Backend with (C#, Web API, EF Core

A brief description of what this project does and who it's for


## Features

- Add images of sportfields (upload, compress, security, 
- Assign imgs by a backend moderation (correct location, quality, 
- 


## Installation

Install my-project with dotnet..

```bash
  npm install my-project
  cd my-project
```


## Environment Variables

To run this project, you will need to add the following environment variables to your .env file

`API_KEY`

`ANOTHER_API_KEY`   
  
   
## Roadmap

- Additional browser support

- Add more integrations


## API Reference

#### Get all items

```http
  GET /api/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.

