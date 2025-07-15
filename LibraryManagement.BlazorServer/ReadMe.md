Library Management System (Blazor Server)

Overview

This repository contains a Blazor Server application implementing a simple Library Management System. It demonstrates:

Entity Framework Core with SQLite and Migrations

A RESTful API layer (BooksController)

Dependency Injection of services

Razor Pages with Bootstrap for CRUD UI

Swagger for API documentation

Clean Architecture principles

Prerequisites

.NET 7 SDK

Visual Studio 2022 / VS Code

SQLite (optional GUI)

Getting Started

Clone repository:

git clone <repo-url>
cd LibraryManagement.BlazorServer

Restore packages:

dotnet restore

Apply EF Core Migrations:

dotnet ef database update

This creates library.db with the Books table.

Run the app:

dotnet run

Blazor UI: https://localhost:5001/

Swagger UI: https://localhost:5001/swagger

Project Structure

/LibraryManagement.BlazorServer
├── Controllers
│   └── BooksController.cs       # API endpoints
├── Data
│   ├── AppDbContext.cs          # EF Core DbContext
│   └── Migrations               # EF Core Migrations
├── Models
│   └── Book.cs                  # Entity & API model
├── Services
│   ├── IBookService.cs          # CRUD interface
│   └── BookService.cs           # EF Core implementation
├── Pages
│   ├── Index.razor              # Home page listing
│   ├── Books.razor              # /books list page
│   ├── Books/Create.razor       # Create form
│   └── Books/Edit.razor         # Edit form
├── Shared
│   ├── MainLayout.razor         # Bootstrap layout
│   └── NavMenu.razor            # Sidebar navigation
├── wwwroot
│   └── css, js, assets
├── Program.cs                   # App startup & DI
├── appsettings.json             # Connection string
├── LibraryManagement.BlazorServer.csproj
└── README.md                    # This file

Key Components

1. Database Schema

EF Core Migrations generate the following DDL:

CREATE TABLE "Books" (
  "BookId"        INTEGER PRIMARY KEY AUTOINCREMENT,
  "Title"         TEXT    NOT NULL,
  "Author"        TEXT    NOT NULL,
  "PublishedDate" TEXT    NOT NULL,
  "Genre"         TEXT    NOT NULL,
  "Price"         NUMERIC NOT NULL
);

2. API Design

Model: Models/Book.cs

Interface: Services/IBookService.cs with methods:

GetBooks()

GetBookById(int)

AddBook(Book)

UpdateBook(Book)

DeleteBook(int)

Implementation: Services/BookService.cs using EF Core

Controller: Controllers/BooksController.cs exposing /api/books

Swagger is enabled via Swashbuckle in Program.cs.

3. Dependency Injection

Configured in Program.cs:

builder.Services.AddDbContext<AppDbContext>(...);
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddControllers();

Controllers and Razor pages declare IBookService in their constructors or @inject.

4. Frontend (Bootstrap + Razor)

Layout: Shared/MainLayout.razor with Bootstrap grid and sidebar

Navigation: Shared/NavMenu.razor using <NavLink>s

Pages:

Home (Index.razor): lists books on landing page

Books (Books.razor): dedicated list at /books

Create (Books/Create.razor): form to add new book

Edit (Books/Edit.razor): form to update existing book

All pages use <table class="table"> and <EditForm> for CRUD.

5. Clean Architecture

Entities: Book lives at the core

Use Cases/Services: IBookService encapsulates business logic

Interface Adapters: BookService, BooksController, Razor pages

Frameworks & Drivers: EF Core, ASP.NET Core, Blazor, SQLite, Swagger

Dependencies always point inward, ensuring separation of concerns and testability.

Feel free to explore code comments for detailed explanations of decisions and patterns. Enjoy!