# Store API
Homework 1 for Hepsiburada Backend Bootcamp.
- RESTful Web API
- Includes two models: Customer & Product
- HTTP methods used: GET, POST, PUT, DELETE
- GET method usage
	--
	- to list all customers
	- to list single customer by ID
	- to list all products
	- to list single product by ID
	- to sort products by a parameter given by user

- POST method usage
	--
	- to create a new customer
	- to create a new product

- PUT method usage
	--
	- to update customer data by ID
	- to update product data by ID

- DELETE method usage
	--
	- to delete a existing customer by ID
	- to delete a existing product by ID

## Examples
- **Get Customers**
> **Request URL:** `localhost:5000/api/v1/customers`
> 
> **HTTP Method:** GET
>
> **Response:** All customers as JSON _(HTTP Status 200 - OK)_
---
- **Get Single Customer By ID**
> **Request URL:** `localhost:5000/api/v1/customers/{id}`
>
> **HTTP Method:** GET
>
> **Response:** Customer info with given ID as JSON _(HTTP Status 200 - OK)_ or _HTTP Status 404 - Not Found_
---
- **Create New Customer**
> **Request URL:** `localhost:5000/api/v1/customers`
>
> **HTTP Method:** POST
>
> **Body Parameter:** Customer data as JSON
>
> ```
> {
>    "id"			: 10,
>    "firstName"		: "Test",
>    "lastName"		: "Person",
>    "gender"		: "F",
>    "email"		: "test@test.com"
> }
> ```
>
> **Response:** _HTTP Status 201 - Created_
---
- **Update Customer**
> **Request URL:** `localhost:5000/api/v1/customers/{id}`
>
> **HTTP Method:** PUT
>
> **Body Parameter:** Customer data as JSON
>
> ```
> {
>    "id"			: 20,
>    "firstName"		: "Update",
>    "lastName"		: "Customer",
>    "gender"		: "M",
>    "email"		: "customer@test.com"
> }
> ```
>
> **Response:** _HTTP Status 200 - OK_ or _HTTP Status 404 - Not Found_
---
- **Delete Customer By ID**
> **Request URL:** `localhost:5000/api/v1/customers/{id}`
>
> **HTTP Method:** DELETE
>
> **Response:** _HTTP Status 200 - OK_ or _HTTP Status 404 - Not Found_
---
- **Get Products**
> **Request URL:** `localhost:5000/api/v1/products`
> 
> **HTTP Method:** GET
>
> **Response:** All products as JSON _(HTTP Status 200 - OK)_
---
- **Get Single Product By ID**
> **Request URL:** `localhost:5000/api/v1/products/{id}`
>
> **HTTP Method:** GET
>
> **Response:** Product info with given ID as JSON _(HTTP Status 200 - OK)_ or _HTTP Status 404 - Not Found_
---
- **Create New Product**
> **Request URL:** `localhost:5000/api/v1/products`
>
> **HTTP Method:** POST
>
> **Body Parameter:** Product data as JSON
>
> ```
> {
>     "id" : 20,
>     "brand" : "IKEA",
>     "name" : "Sofa",
>     "category" : "Furniture",
>     "price" : 469.90
> }
> ```
>
> **Response:** _HTTP Status 201 - Created_
---
- **Update Product**
> **Request URL:** `localhost:5000/api/v1/products/{id}`
>
> **HTTP Method:** PUT
>
> **Body Parameter:** Product data as JSON
>
> ```
> {
>     "id" : 21,
>     "brand" : "IKEA",
>     "name" : "Wardrobe",
>     "category" : "Furniture",
>     "price" : 110
> }
> ```
>
> **Response:** _HTTP Status 200 - OK_ or _HTTP Status 404 - Not Found_

---
- **Sort Products**
> **Request URL:** `localhost:5000/api/v1/products/sort?sortBy={property}`
>
> **HTTP Method:** GET
>
> **Query Parameters:** "brand", "name", "category", "price"
>
> **Response:** All products sorted by given parameter as JSON _(HTTP Status 200 - OK)_ or _HTTP Status 400 - Bad Request_ or _HTTP Status 500 - Internal Server Error_
---
- **Delete Products By ID**
> **Request URL:** `localhost:5000/api/v1/products/{id}`
>
> **HTTP Method:** DELETE
>
> **Response:** _HTTP Status 200 - OK_ or _HTTP Status 404 - Not Found_
