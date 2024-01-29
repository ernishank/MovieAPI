# Movie API Setup Instructions

## 1. Update Datasource Name

Update the `Datasource` name in the `appsettings.json` file to match your SQL Server instance. Locate the `"ConnectionStrings"` section and update the `"DefaultConnection"` value with your server name.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<YourServerName>;Database=MovieDb;Integrated Security=True;"
  },
  // ... other configurations
}

## 2. Create Database

Execute the following SQL command to create the database:
create database MovieDb;

## 3. Recommended .NET Version
It is highly recommended to use .NET 8 to execute the API. Ensure that you have .NET 8 installed on your system before running the application.

## 4. Execute Database Migration
Run the following command in the terminal or Package Manager Console to apply the database migrations and create the required tables:
dotnet ef database update

This command will create the necessary tables in the MovieDb database.

Now, you should be ready to run and test the Movie API.