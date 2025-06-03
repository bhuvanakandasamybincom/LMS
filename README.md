# LMS Library Management System

# Nuget packages 
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer 

# Library Management system work flow
## 1. Register endpoint to register the User/Admin role along with login credentials:
    It will be stored in the database using the UserManager ASP.NET Core default code
	  We do not need to create any table structure for this. The UserManager Code will be created by itself.
	  Note: By default, the account will be created with the User role. If you want to change the access permission, follow the next step: 7
## 2. Use the login endpoint to generate a JWT token
    Sample JWT token like below
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImpvaG5kb2UiLCJqdGkiOiJhNDg1Y2YzOC05ZWM0LTQxNTUtOWNhYy02ZjczZWI4ZDUxYWEiLCJyb2xlIjoiVXNlciIsIm5iZiI6MTc0ODU2OTM1NywiZXhwIjoxNzQ4Nzg1MzQxLCJpYXQiOjE3NDg1NjkzNTcsImlzcyI6IkJodXZhbmEiLCJhdWQiOiJCaHV2YW5hX0sifQ.nptIZDPjbGYtvyxlIvvCIdFFN0b8SUyKPpBWrDHeUf4

## 3. To access the API on Postman IDE along with a JWT token
    On postman goto-> Authorization section -> Select "Bearer Token" option on left -> Paste the above token on right side field WITHOUT "Bearer" text
## 4. Run the AddAuthor API endpoint 
    To add a new author
## 5. Run the AddBook API endpoint 
    To add a new book
## 6. GetBook API endpoint 
    To get a list of books
## 7. changeRole API endpoint 
    To change the user's role. (The user with Admin privilege can only access this.)
