using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
class Program
{
    static string connectionString = "mydb.db";

    static void Main(string[] args)
    {
        Console.WriteLine("1. Create a new database");
        Console.WriteLine("2. Create a table");
        Console.WriteLine("3. Insert data");
        Console.WriteLine("4. Update data");
        Console.WriteLine("5. Delete data");
        Console.WriteLine("6. Selection by condition");
        Console.WriteLine("7. Show all data");
        Console.Write("Select an operation: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            using SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            switch (choice)
            {
                case 1:
                    CreateDatabase(connection);
                    break;
                case 2:
                    CreateTable(connection);
                    break;
                case 3:
                    InsertData(connection);
                    break;
                case 4:
                    UpdateData(connection);
                    break;
                case 5:
                    DeleteData(connection);
                    break;
                case 6:
                    SelectData(connection);
                    break;
                case 7:
                    ShowAllData(connection);
                    break;
                default:
                    Console.WriteLine("Incorrect operation selection.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Incorrect input.");
        }
    }

    static void CreateDatabase(SQLiteConnection connection)
    {
        Console.Write("Enter a name for the new database: ");
        string dbName = Console.ReadLine();
        connection.ChangeDatabase(dbName);
    }

    static void CreateTable(SQLiteConnection connection)
    {
        Console.Write("Enter a name for the table: ");
        string tableName = Console.ReadLine();
        Console.Write("Enter the table fields and their data types: ");
        string fields = Console.ReadLine();
        string query = $"CREATE TABLE IF NOT EXISTS {tableName} ({fields})";
        ExecuteQuery(connection, query);
    }

    static void InsertData(SQLiteConnection connection)
    {
        Console.Write("Введіть назву таблиці: ");
        string tableName = Console.ReadLine();
        Console.Write("Введіть дані для вставки (наприклад, 'John', 25): ");
        string data = Console.ReadLine();
        string query = $"INSERT INTO {tableName} VALUES ({data})";
        ExecuteQuery(connection, query);
    }

    static void UpdateData(SQLiteConnection connection)
    {
        Console.Write("Введіть назву таблиці: ");
        string tableName = Console.ReadLine();
        Console.Write("Введіть дані для оновлення (наприклад, name = 'Alice' WHERE id = 1): ");
        string updateData = Console.ReadLine();
        string query = $"UPDATE {tableName} SET {updateData}";
        ExecuteQuery(connection, query);
    }

    static void DeleteData(SQLiteConnection connection)
    {
        Console.Write("Введіть назву таблиці: ");
        string tableName = Console.ReadLine();
        Console.Write("Введіть умову видалення (наприклад, id = 2): ");
        string condition = Console.ReadLine();
        string query = $"DELETE FROM {tableName} WHERE {condition}";
        ExecuteQuery(connection, query);
    }

    static void SelectData(SQLiteConnection connection)
    {
        Console.Write("Введіть назву таблиці: ");
        string tableName = Console.ReadLine();
        Console.Write("Введіть умову вибірки (наприклад, age > 30): ");
        string condition = Console.ReadLine();
        string query = $"SELECT * FROM {tableName} WHERE {condition}";
        ExecuteQueryAndDisplay(connection, query);
    }

    static void ShowAllData(SQLiteConnection connection)
    {
        Console.Write("Введіть назву таблиці: ");
        string tableName = Console.ReadLine();
        string query = $"SELECT * FROM {tableName}";
        ExecuteQueryAndDisplay(connection, query);
    }

    static void ExecuteQuery(SQLiteConnection connection, string query)
    {
        using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
        {
            cmd.ExecuteNonQuery();
        }
    }

    static void ExecuteQueryAndDisplay(SQLiteConnection connection, string query)
    {
        using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
        {
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
