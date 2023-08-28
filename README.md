# OpencartShop
# Back-end API
### Introduction

This API is based on REST-Api using GET, POST, PUT, DELETE methods. It provides the following capabilities: 
- directory management
- user registration
- user authentication
- adding products and information about them
- order placement
- shopping cart (in dev)
- leaving feedback (in dev)
- and other (in dev)

---
---

## Authorization
All API requests require the use of a generated API key. This api using jwt-token.

### Login Request

```http
POST /Account/Login
```

#### Request Body

```
{
    "email":"<mail>",
    "password":"<pass>"
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `email` | `string` | **Required**. User email|
| `password` | `string` | **Required**. User password|

### Response

```
{
    "token":"<token>"
}
```
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `token` | `string` | jwt-token for authorization|

All request, what using `jwt-token` marked ``[Auth]`` in this document. Client app must add `"Authorization"` header with value: `"Bearer <token>"`.

--------------
### Registration Request

```http
POST /Account/Registration
```
#### Request Body

```
{
    "FirstName":"Tom",
    "LastName":"Gray",
    "Password": "1234pass",
    "Email": "toma@mail.com",
    "Phone": "+380123456779"
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `FirstName` | `string` | **Required** User first name|
| `LastName` | `string` | **Required** User last name|
| `Password` | `string` | **Required** User password|
| `Email` | `string` | **Required** User email|
| `Phone` | `string` | User last name|
---
---
## Catalog
### Get all Catalogs
### Request 
```http
GET /Catalog/Catalogs
```
### Response
This request getting  all catalogs with subcataloges and categories
```
[
    {
        "Id": 1,
        "Title": "Some catalog",
        "SubCatalogs":[
            {
                "Id": 1,
                "Title" : "Some Subcatalog",
                "ParentCatalog": 1,
                "Categories":[
                    {
                        "Id": 1,
                        "Title" : "Some category",
                        "SubcategoryId": 1
                    }
                ]
            },
            ...
        ]
    },
    ...
]
```
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Id` | `string` | Every entity has uniqui  |
| `Title` | `string` | Name of (Catalog, subcatalog, category)|
---
### Get all SubCatalogs
### Request 
```http
GET /Catalog/SubCatalogs
```
### Response
This request getting  all subcataloges.
```
[
    {
        "Id": 1,
        "Title" : "Some Subcatalog",
        "ParentCatalog": 1,
        "Categories":[
            {
                "Id": 1,
                "Title" : "Some category",
                "SubcategoryId": 1
            },
            ...
        ]
    },
    ...
]
```

---
### Get all Categories
### Request 
```http
GET /Catalog/Categories
```
### Response
This request getting  all categories.
```
[
    {
        "Id": 1,
        "Title" : "Some category",
        "SubcategoryId": 1
    },
    ...
]
```
---
### Get Catalog by id
### Request 
```http
GET /Catalog/GetCatalog/{id}
```
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `id` | `int` | **Required** The identifier of the catalog we want to get  |
### Response
```
{
    "Id": 1,
    "Title": "Some catalog",
    "SubCatalogs":[
        {
            "Id": 1,
            "Title" : "Some Subcatalog",
            "ParentCatalog": 1,
            "Categories":[
                {
                    "Id": 1,
                    "Title" : "Some category",
                    "SubcategoryId": 1
                }
            ]
        },
        ...
    ]
}
```
---
### Get Category by id
### Request 
```http
GET /Catalog/GetCategory/{id}
```
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `id` | `int` | **Required** The identifier of the catalog we want to get  |
### Response
```
{
    "Id": 1,
    "Title" : "Some category",
    "SubcategoryId": 1
}
```
---
### Get Subcatalog by id
### Request 
```http
GET /Catalog/GetSubCatalog/{id}
```
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `id` | `int` | **Required** The identifier of the catalog we want to get  |
### Response
```
{
    "Id": 1,
    "Title" : "Some Subcatalog",
    "ParentCatalog": 1,
    "Categories":[
        {
            "Id": 1,
            "Title" : "Some category",
            "SubcategoryId": 1
        }
    ]
}
```
---
### AddCatalog
### Request `[Auth]`
```http
POST /Catalog/AddCatalog/
```
#### Body
```
{
    "Title":"Some title"
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Title` | `string` | **Required** Some name  |

### Response
```
200 OK
```
---

### AddSubCatalog
### Request `[Auth]`
```http
POST /Catalog/AddSubCatalog/
```
#### Body
```
{
    "Title":"Some title",
    "ParentCatalog": 1
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Title` | `string` | **Required** Some name  |
| `ParentCatalog` | `int` | **Required** The identifier of catalog  |

### Response
```
200 OK
```
---
### AddCategory
### Request `[Auth]`
```http
POST /Catalog/AddCategory/
```
#### Body
```
{
    "Title":"Some title",
    "SubcategoryId": 1
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Title` | `string` | **Required** Some name  |
| `SubCatalogId` | `int` | **Required** The identifier of SubCatalog  |

### Response
```
200 OK
```
---
### EditCatalog
### Request `[Auth]`
```http
PUT /Catalog/EditCatalog/
```
#### Body
```
{
    "Id": 1
    "Title":"Some title"
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Id` | `int` | **Required** The identifier of catalog  |
| `Title` | `string` | **Required** New or old title  |

### Response
```
200 OK
```
---
### EditCategory
### Request `[Auth]`
```http
PUT /Catalog/EditCategory/
```
#### Body
```
{
    "Id": 1
    "Title":"Some title",
    "SubCatalogId": <value>
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Id` | `int` | **Required** The identifier of catalog  |
| `Title` | `string` | **Required** New or old title  |
| `SubCatalogId` | `int` | **Required** New or old value  |

### Response
```
200 OK
```
---
### EditSubCatalog
### Request `[Auth]`
```http
PUT /Catalog/EditSubCatalog/
```
#### Body
```
{
    "Id": 1
    "Title":"Some title",
    "ParentCatalog": <value>
}
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Id` | `int` | **Required** The identifier of catalog  |
| `Title` | `string` | **Required** New or old title  |
| `ParentCatalog` | `int` | **Required** New or old value  |

### Response
```
200 OK
```
---
### DeleteCategory
### Request `[Auth]`
```http
DELETE /Catalog/DeleteCategory/{id}
```
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Id` | `int` | **Required** The identifier of category for delete |

### Response
```
200 OK
```
---
### DeleteSubCatalog
### Request `[Auth]`
```http
DELETE /Catalog/DeleteSubCatalog/{id}
```
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Id` | `int` | **Required** The identifier of subcatalog for delete |

### Response
```
200 OK
```
---
---
