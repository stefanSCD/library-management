# Library Management System

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2+-purple.svg)](https://dotnet.microsoft.com/download/dotnet-framework)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-red.svg)](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

A comprehensive Windows desktop application for managing library operations, built with WPF and SQL Server LocalDB.

![Library Management System Dashboard](screenshots/dashboard.png)

## ✨ Features

- 📚 **Book Management** - Add, edit, delete, and search books
- 📖 **Loan Management** - Track book borrowing and returns
- 📊 **Analytics Dashboard** - Visual reports with charts and statistics
- 🔍 **Advanced Search** - Find books by title or author

## 🌟 Innovative Feature: Analytics Dashboard

For requirement #7, I implemented an **Analytics Dashboard** that provides comprehensive insights into library operations through interactive charts and visualizations.


#### 📊 Visual Analytics Components:

1. **Most Borrowed Books Chart (Pie Chart)**
   - Displays the top N most borrowed books (configurable: 5, 10, or 20 books)
   - Visual representation with percentages
   - Helps identify popular titles for acquisition decisions
   - Interactive legend showing book titles and authors

2. **Borrowing Trends Analysis (Line Chart)**
   - Shows borrowing patterns over time
   - Three time period options:
     - Daily (last 30 days)
     - Weekly (last 6 months)
     - Monthly (last 12 months)
   - Helps identify peak borrowing periods
   - Useful for staff scheduling and inventory management


### Prerequisites

Before you begin, ensure you have the following installed:

- Windows 10 or later
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) or higher
- [SQL Server LocalDB 2019](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) or higher
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (for development)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/stefanSCD/library-management.git
