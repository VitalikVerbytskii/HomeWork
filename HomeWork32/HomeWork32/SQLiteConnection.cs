internal class SQLiteConnection
{
    public SQLiteConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; }

    internal void ChangeDatabase(string? dbName)
    {
        throw new NotImplementedException();
    }

    internal void Open()
    {
        throw new NotImplementedException();
    }

}