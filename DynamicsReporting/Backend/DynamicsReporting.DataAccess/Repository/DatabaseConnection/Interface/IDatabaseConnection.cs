using System.Data;

public interface IDatabaseConnection
{
    IDbConnection CreateConnection();

}