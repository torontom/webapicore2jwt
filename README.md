# Example of REST API Using .NET Core 2.0, JWT Authentication and MongoDB.

## This is a clone of [this project](https://github.com/fabioono25/webapicore2jwt), it's **fully working** and I **like** it.

### Technologies:

- .NET Core 2.0;
- MongoDB;
- JWT Authentication.

### Running this solution:

First of all, download or clone the project to a local directory.

Then you need to create a local MongoDB instance. In this example, create a database named as **ProductDb** and two collections: **Product** and **User**, then use the following command to insert a document into **User**, you can also do it with **MongoDB Compass** if you have it installed:

```javascript
db.User.insert({"Name": "Joao Teste", "Login": "joao", "Password": "1234"})
```

![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/mongodb.png "MongoDB Configuration")

It's necessary to configure **appsettings.json** with your instance of MongoDB:

```javascript
"ConnectionString": "mongodb://localhost:27017",
```

Next, you can open you project in Visual Studio or Visual Studio Code. You can type these two commands (to restore nuget package components and run the API):

```javascript
dotnet restore
```

```javascript
dotnet run
```

Now, if everything is all right, your API will be working. Do the following POST in postman so you can get an authentication token (your port number might be different):

```javascript
POST http://localhost:5000/api/Auth
```

With payload:

```javascript
{
	"Login": "joao",
	"Password": "1234"
}
```

The result is like this:

![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/postmantoken.png "Postman Token")

You must use this token so you can use GET, POST, PUT, DELETE verbs. For every of these REST verbs, you must put the generated token in **Authorization Header**, with the word **Bearer** like this:

```javascript
Header: Authorization
Value: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqb2FvIiwianRpIjoiMTFlYWFlODMtZTA4NS00NjA1LTlhNGQtZWI5ZjEzZjdhMDk5IiwiTWVtYmVyc2hpcElkIjoiMTExIiwiZXhwIjoxNTEwMTk0NjQ5LCJpc3MiOiJpc3N1ZXJUZXN0IiwiYXVkIjoiYmVhcmVyVGVzdCJ9.mN3uPfdK19xeMbOoeFfhtuFSpXrGUZ7eR6muM7Nz_fo
```

To use POST, so you can insert some Products, use this URL bellow:

```javascript
POST http://localhost:5000/api/Products
```

With this payloads:

```javascript
{
    "Code": "COD1",
    "Name": "Produto 1",
    "Active": true,
    "ImageUrl": "http://download.gamezone.com/uploads/image/data/1102202/League_of_Legends_Rune_Wars_Renekton.jpg",
	"Description": "Descrição do Produto 1"
}
```
```javascript
{
    "Code": "COD2",
    "Name": "Produto 2",
    "Active": true,
    "ImageUrl": "http://images.nintendolife.com/news/2014/08/weirdness_yoshis_real_name_is_both_silly_and_scientific/attachment/0/900x.jpg",
	"Description": "Descrição do Produto 2"	
}
```
```javascript
{
    "Code": "COD3",
    "Name": "Produto 3",
    "Active": true,
    "ImageUrl": "http://da-v4-mbl.digitalbrandsinc.netdna-cdn.com/wp-content/uploads/2012/08/snails-612x320.jpg",
	"Description": "Descrição do Produto 3"	
}
```

Now you can list the products inserted. Use this URL:

```javascript
GET http://localhost:60757/api/Products
```

![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/postmanok.png "Postman Product List")


Remember, we are using a JWT Token Authentication. The definition of the expiration is 20 minute. Because of this, you maybe get **Error 401 - Unauthorized**. It's perfectly normal: 


![Alt text](https://github.com/fabioono25/webapicore2jwt/blob/master/Images/postmanUnauthorized.png "Postman Unauthorized")

You just generate another token and put it on Header Authorization.


