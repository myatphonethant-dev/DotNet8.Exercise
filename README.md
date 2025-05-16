# 🚀 DotNet8.Exercise

A collection of .NET 8 exercises demonstrating different data access technologies with Console UI examples.

![.NET](https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12-239120?logo=c-sharp)
![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?logo=microsoft-sql-server)

## 📋 Projects Overview

### 1. 🖥️ ConsoleUI
A basic console application demonstrating user interface interactions.

**✨ Features:**
- � Simple menu system
- ⌨️ User input handling
- 🎨 Basic console formatting

### 2. ⚡ AdoNetExercise
Raw ADO.NET database operations with SQL Server.

**🔑 Key Components:**
- `SqlConnection` for database connectivity
- `SqlCommand` for executing queries
- 🔒 Parameterized queries for security
- CRUD operations implementation

### 3. 🏎️ DapperExercise
Lightning-fast data access with Dapper.

**🚀 Features:**
- Simplified ORM mapping
- ⚡ Performance-focused
- Basic and advanced query examples

**📦 Dependencies:**
- Dapper
- System.Data.SqlClient

### 4. 🏗️ EFCoreExercise
Full-featured ORM with Entity Framework Core.

**🌉 Features:**
- DbContext configuration
- 🏗️ Code-first approach
- LINQ queries
- 🏃 Migrations
- ↔️ Relationship configurations

## 🚦 Getting Started

### 📋 Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or modify connection strings)
- (Optional) Visual Studio 2022 or VS Code

## 🔍 Technology Comparison

| Feature           | ADO.NET         | Dapper          | EF Core         |
|-------------------|-----------------|-----------------|-----------------|
| **Abstraction**   | Low-Level       | Medium          | High-Level      |
|                   | (Manual SQL)    | (Micro ORM)     | (Full ORM)      |
| **Performance**   | ⚡⚡⚡⚡⚡        | ⚡⚡⚡⚡          | ⚡⚡⚡            |
| **Speed**         | 🐢 Slow         | 🐇 Fast         | 🚀 Rapid        |
| **SQL Required**  | ✅ Always       | ✅ Yes          | ❌ Optional     |
| **Learning Curve**| 📈 Steep        | 📉 Moderate     | 📉 Gentle       |
| **Use Case**      | Performance-critical | Balanced needs | Rapid development |
| **Complexity**    | High            | Medium          | Low             |
| **Lines of Code** | More            | Less            | Least           |


