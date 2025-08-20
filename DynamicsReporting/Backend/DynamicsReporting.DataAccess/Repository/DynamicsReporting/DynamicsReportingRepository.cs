using Microsoft.Data.SqlClient;
using System.Data;
using System.Dynamic;



public class DynamicsReportingRepository : IDynamicsReportingRepository
{
    public async Task<List<ExpandoObject>> ExecuteStoredProcedureAsync(string connectionString, string spName, Dictionary<string, object>? parameters)
    {
        var result = new List<ExpandoObject>();

        try
        {
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(spName, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                IDictionary<string, object> row = new ExpandoObject();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = await reader.IsDBNullAsync(i) ? null : reader.GetValue(i);
                }

                result.Add((ExpandoObject)row);
            }
        }
        catch (Exception ex)
        {
            throw;
        }

        return result;
    }

    public async Task<IEnumerable<ExpandoObject>> ExecuteStoredProcedureAsync(string connStr, string sp, int parameter)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@Parameter", parameter }
        };

        return await ExecuteStoredProcedureAsync(connStr, sp, parameters);
    }
}
