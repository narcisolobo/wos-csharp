# Entity Framework Core

Entity Framework Core (EF Core) is an open-source, lightweight, extensible, and cross-platform version of Entity Framework, a popular Object-Relational Mapping (ORM) framework for .NET. EF Core allows developers to interact with a database using .NET objects, making it easier to work with relational data in applications without having to write raw SQL queries.

## Key Features of EF Core:

1.	Cross-Platform: EF Core can be used on Windows, Linux, and macOS.
2.	Lightweight and Extensible: It is designed to be lightweight and extensible with support for dependency injection.
3.	Migrations: EF Core supports migrations, allowing developers to evolve the database schema over time in a consistent way.
4.	LINQ Queries: EF Core allows developers to write database queries using LINQ (Language Integrated Query), making queries easier to write and read.
5.	Change Tracking: It keeps track of changes to entities and automates the process of updating the database.
6.	Eager, Lazy, and Explicit Loading: EF Core supports various loading strategies to control how related data is fetched from the database.
7.	Support for Multiple Database Providers: EF Core supports multiple database providers, such as SQL Server, SQLite, MySQL, PostgreSQL, and others.

## Basic Concepts:

1.	DbContext: The primary class responsible for interacting with the database. It represents a session with the database and provides methods for querying and saving data.
2.	Entities: Classes that represent the data you want to query and save. Each entity corresponds to a table in the database.
3.	DbSet: Represents a collection of entities that can be queried and saved.
4.	Configurations: EF Core uses configurations (either through data annotations or Fluent API) to map classes to database tables, specify primary keys, relationships, constraints, etc.