# BraiseBreakfast
RESTAPI built with ASP.NET7 for a breakfast website. It offers all CRUD functionality for the website such as creating breakfast, reading breakfast, updating breakfast and deleting breakfast.

# Technologies:
1. ASP.NET 7
2. dotnet CLI (runtime and sdk)
3. Neovim (code editor)
4. Omnisharp Language server (LSP)
5. Null_ls for formatting (neovim plugin)

# Usage
1. Clone the repository
   ```bash
   git clone https://github.com/Clinton-Nmereole/BraiseBreakfast/
   ```
2. Go to project Directory
   ```bash
   cd BraiseBreakfast
   ```
3. Run Project
   ```bash
   dotnet run --project ./BuberBreakfast
   ```
4. Test results with Postman

# BraiseBreakfast API

- [BraiseBreakfast API](#braise-breakfast-api)
  - [Create Breakfast](#create-breakfast)
    - [Create Breakfast Request](#create-breakfast-request)
    - [Create Breakfast Response](#create-breakfast-response)
  - [Get Breakfast](#get-breakfast)
    - [Get Breakfast Request](#get-breakfast-request)
    - [Get Breakfast Response](#get-breakfast-response)
  - [Update Breakfast](#update-breakfast)
    - [Update Breakfast Request](#update-breakfast-request)
    - [Update Breakfast Response](#update-breakfast-response)
  - [Delete Breakfast](#delete-breakfast)
    - [Delete Breakfast Request](#delete-breakfast-request)
    - [Delete Breakfast Response](#delete-breakfast-response)

## Create Breakfast

### Create Breakfast Request

```js
POST /breakfasts
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
	  "imageUrl": "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fimage&psig=AOvVaw2M6eqVspNa6CElVfa14-fP&ust=1698866021724000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPC72J__oIIDFQAAAAAdAAAAABAE",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Create Breakfast Response

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "imageUrl": "some Img's url",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Get Breakfast

### Get Breakfast Request

```js
GET /breakfasts/{{id}}
```

### Get Breakfast Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "imageUrl": "some Img's url",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Update Breakfast

### Update Breakfast Request

```js
PUT /breakfasts/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "imageUrl": "some Img's url",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Breakfast Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

## Delete Breakfast

### Delete Breakfast Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Breakfast Response

```js
204 No Content
```
# Credits
1. FreeCodeCamp youtube channel and website: https://www.youtube.com/@freecodecamp and https://www.freecodecamp.org/
2. Buber-breakfast by https://github.com/amantinband: Link to project: https://github.com/amantinband/buber-breakfast/tree/main
3. Video tutorial for project: https://www.youtube.com/watch?v=PmDJIooZjBE&list=PLbHoFtW5JkYZZ_aawNaCoZ05Qi5fCPVY-&index=289
4. ErrorOr - A simple, fluent discriminated union of an error or a result.
