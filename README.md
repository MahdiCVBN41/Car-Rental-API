# 🚗 Car Rental API

A robust RESTful API built with **.NET 8**, **SQL Server**, and **Dapper** for managing car rentals, customers, and payments. This project strictly follows a layered architecture (Controllers → Services → Repositories) with **raw SQL queries** for all database operations.

---

## 📋 Project Requirements (Fulfilled)
- ✅ Built with **.NET 8** and **SQL Server**.
- ✅ Database contains **Cars**, **Customers**, **Rentals**, and **Payments**.
- ✅ Architecture split into **Controllers**, **Services**, **Repositories**, **Models**, and **DTOs**.
- ✅ All database functions written using **raw SQL** (`SELECT * FROM...`, `INSERT INTO...`, etc.) via **Dapper**.
- ✅ Complete CRUD operations for all entities.
- ✅ Business logic implementation (e.g., age validation, outstanding balance checks).
- ✅ Dependency Injection for decoupling and testability.

---

## 🏗️ Architecture Overview

This API follows the **Layered Architecture** pattern to ensure separation of concerns:

| Layer | Responsibility |
| :--- | :--- |
| **Controllers** | Handle HTTP requests, model binding, and route responses. |
| **Services** | Contain all **business logic** (validations, calculations, orchestration). |
| **Repositories** | Execute **raw SQL queries** against SQL Server. |
| **Models** | Represent database entities (dumb data holders). |
| **DTOs** | Define the shape of data entering/leaving the API. |
| **Mappings** | AutoMapper profiles to convert between Models and DTOs. |

---

## 🗄️ Database Schema

The database consists of four main tables:

- **Cars** (CarId, Make, Model, Year, LicensePlate, DailyRate, IsAvailable)
- **Customers** (CustomerId, FirstName, LastName, Email, Phone, Address, DriverLicenseNumber, DateOfBirth)
- **Rentals** (RentalId, CarId, CustomerId, RentalDate, ReturnDate, TotalCost, Status)
- **Payments** (PaymentId, RentalId, Amount, PaymentDate, PaymentMethod, TransactionId)

> The SQL schema creation script is available in the project documentation.

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or Developer Edition)
- [Visual Studio Code](https://code.visualstudio.com/) (or any IDE)

### 1. Clone the Repository
```bash
git clone https://github.com/YourUsername/CarRentalAPI.git
cd CarRentalAPI
execute all requirements on the requirement.txt file
