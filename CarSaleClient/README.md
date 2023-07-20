# Car Sale

## Use instructions

1. Clone the repository.

- `git@github.com:lovomax/CarSale.git`.
- - Enter the folder of the repository you've just cloned
  - `cd CarSale`

2. Install the dependencies and initialize the project.

To build the project's backend and the SqlServer Database.
 - `dotnet build --project CarSaleServer`
 - `dotnet ef database update`

To install the dependencies of the project's frontend, enter the CarSaleClient folder.
  - `cd CarSaleClient`
  - `yarn`

By initializing the backend you are provided with an Admin account, the following variables are the credentials needed to use the application correctly.

 - `Username`= `admin`
 - `Password` = `admin`

After configuring the server and the frontend, we already have all we need to start using the application, all that's left is to run the following commands to start the application:

 - On the application's CarSaleServer folder:
 - - `dotnet run --project CarSale`
 - On the application's CarSaleServer folder:
 - - `yarn start`

 ### Administrative flow
 
 After logging in, you will be redirected to the homepage, where you can move between pages in the application, in here, you will be capable to move to:

 - Buy Cars: Allows the user to see all of the registered cars
 - Sell Car: Allows for the creation of a new car
 - Logging in (if you are still not logged in)
 - Details of the Car: In here you can update the general data and image of the car or outright delete it.

## API Documentation

<br/>

### **Log-in**

##### `POST` /api/Auth/login

<br/>

The endpoint does a validation for the login and returns a token for authentication

- example `request body`

  ```json
  {
    "username": "admin",
    "password": "admin"
  }
  ```

  - example `response body`

  ```json
  {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQ3N2IyOTlhLTIzMWYtNDBkYS05N2MzLWFjNzUyNjU0NTI2ZiIsImZ1bGxuYW1lIjoiSm9zZSBEYW5pZWwgQXJyZWF6YSBQdWVydGEiLCJ1c2VybmFtZSI6ImpkYW5pZWxfYXAiLCJlbWFpbCI6ImFkbWluQGFkbWluLmNvbSIsIm1lZGljUm9sZSI6dHJ1ZSwiaWF0IjoxNjMxNDQ2MDUxLCJleHAiOjE2MzE0NDYzNTEsInN1YiI6IjQ3N2IyOTlhLTIzMWYtNDBkYS05N2MzLWFjNzUyNjU0NTI2ZiJ9.HgKfpimfS1ExsvkXMcgNx09GAiaO1yxzI4qfrtStS_o",
  "success": true,
  "message": ""
  }
  ```

<br/>

### **Get cars**

##### `GET` api/Car/getallcars

<br/>

This endpoint returns all of the registered cars

 - Example `request`
  No parameters required

 - Example `response`

 ```json
 "data": [
    {
      "id": 0,
      "name": "string",
      "model": "string",
      "kilometers": 0,
      "price": 0,
      "year": "2022-11-12T17:17:40.795Z",
      "make": {
        "name": "string"
      },
      "photo": {
        "photoURL": "string",
        "publicId": "string"
      }
    },
    {
      "id": 1,
      "name": "string",
      "model": "string",
      "kilometers": 0,
      "price": 0,
      "year": "2022-11-12T17:17:40.795Z",
      "make": {
        "name": "string"
      },
      "photo": {
        "photoURL": "string",
        "publicId": "string"
      }
    }
  ],
  "success": true,
  "message": ""
 ``` 
  <br/>

###  **Get car**

#### `GET` /api/Car/:id


This endpoint returns to the user the information of the specified car

<br/>

 - Example `request`


 - Example `response`

 ```json
 {
  "data": {
    "id": 0,
    "model": "string",
    "name": "string",
    "kilometers": 0,
    "price": 0,
    "color": "string",
    "year": "2022-11-12T17:29:07.929Z",
    "make": {
      "name": "string"
    },
    "photo": {
      "photoURL": "string",
      "publicId": "string"
    }
  },
  "success": true,
  "message": ""
 }
 ```

<br/>

### **Add car** [Authorize]

#### `POST` /api/Car/addcar

<br/>

This endpoint allows for the creation of a new Car

- Example `request`

 - `headers`

 ```json
 {
   "Content-Type": "multipart/form-data",
   "Authorization": "(Login Token)"
 }
 ```
 
- Example `request body`

 ```json
 {
  "model": "string",
  "name": "string",
  "price": 0,
  "color": "string",
  "kilometers": 0,
  "year": "2022-11-12T17:33:46.367Z",
  "makeId": 0
 }
 ```

- Example `response`

 ```json
 {
  "data": {
    "id": 0,
    "model": "string",
    "name": "string",
    "kilometers": 0,
    "price": 0,
    "color": "string",
    "year": "2022-11-12T17:33:46.371Z",
    "make": {
      "name": "string"
    },
    "photo": {
      "photoURL": "string",
      "publicId": "string"
    }
  },
  "success": true,
  "message": ""
 }
 ```

<br/>

### **Update car** [Authorize]

##### `PUT` /api/Car/updatecar

<br/>

The endpoint returns the updated entity and updates the database

- Example `request`
 
 - `headers`

 ```json
 {
   "Content-Type": "multipart/form-data",
   "Authorization": "(Login Token)"
 }
 ```

 - Example `request body`

 ```json
 {
  "id": 0,
  "model": "string",
  "name": "string",
  "kilometers": 0,
  "price": 0,
  "color": "string",
  "year": "2022-11-12T17:40:07.730Z"
 }
 ```

- Example `response body`

 ```json
 {
  "data": {
    "id": 0,
    "model": "string",
    "name": "string",
    "kilometers": 0,
    "price": 0,
    "color": "string",
    "year": "2022-11-12T17:40:07.741Z",
    "make": {
      "name": "string"
    },
    "photo": {
      "photoURL": "string",
      "publicId": "string"
    }
  },
  "success": true,
  "message": "string"
 }
 ```

<br/>

### **Delete car** [Authorize]

##### ``DELETE` api/Car/deletecar/:id

<br/>

The endpoint deletes an endpoint 

 - Example `request`

 - `headers`

 ```json
 {
   "Content-Type": "multipart/form-data",
   "Authorization": "(Login Token)"
 }
 ```

 - Example `response body`

  ```json
  {
    "data": "the car has been deleted",
    "message": "operation complete",
    "success": "true"
  }
  ```

<br/>

### **Get photo**

##### `GET` /api/Image/get/{request}

<br/>

The endpoint returns a photo with a certain ID

 - Example `request`

 - `headers`

 ```json
 {
   "Content-Type": "multipart/form-data",
   "Authorization": "(Login Token)"
 }
 ```

 - Example `response body`

 ```json
 {
   "data": {
     "photoURL": "string",
     "publicId": "string",
     "timeStamp": "string"
   },
   "success": true,
   "message": "string"
 }
 ```

<br/>

### **Add photo** [Authorize]

##### `POST` /api/Image/add

<br/>

The endpoint registers a photo under a car id

 - Example ``request`
 string($binary)File, integer($int32) CarId

 - `headers`

 ```json
 {
   "Content-Type": "multipart/form-data",
   "Authorization": "(Login Token)"
 }
 ```


 - Example `response body`

 ```json
 {
   "data": {
     "photoURL": "string",
     "publicId": "string",
     "timeStamp": "string"
   },
   "success": true,
   "message": "string"
 }
 ```
<br/>

### **Update photo** [Authorize]

##### `PUT` /api/Image/update

<br/>

The endpoint updates a photo and its URL

- Example ``request`
 string($binary)File, string PublicId

 - `headers`

 ```json
 {
   "Content-Type": "multipart/form-data",
   "Authorization": "(Login Token)"
 }
 ```


 - Example `response body`

 ```json
 {
   "data": {
     "photoURL": "string",
     "publicId": "string",
     "timeStamp": "string"
   },
   "success": true,
   "message": "string"
 }
```

<br/>


### **Delete photo** [Authorize]

##### `DELETE` /api/Image/delete

<br/>

This endpoint deletes a photo in the database and in the service.

- Example `request`

 - `headers`

 ```json
 {
   "Content-Type": "multipart/form-data",
   "Authorization": "(Login Token)"
 }
 ```

 -`request body`

 ```json
  {
    "publicId": "string"
  }
 ```

 -example `response body`

 {
   "data": "string",
   "success": true,
   "message": "string"
 }

<br/>

 The endpoints with the tag [Authorize] can only be used by a registered user.