using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;



[ApiController]
[Route("api/[controller]")]
public class DynamicSqlController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public DynamicSqlController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("execute")]
    public async Task<IActionResult> ExecuteSql([FromBody] SqlConfigRequest request)
    {
        var results = new List<object>();

        foreach (var item in request.ConfSql)
        {
            var connectionString = _configuration.GetConnectionString(item.Db);
            if (string.IsNullOrEmpty(connectionString))
                return BadRequest($"Connection string for DB '{item.Db}' not found.");

            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(item.Sp, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            await conn.OpenAsync();

            var reader = await cmd.ExecuteReaderAsync();
            var table = new DataTable();
            table.Load(reader);

            results.Add(new
            {
                Database = item.Db,
                Procedure = item.Sp,
                Data = table
            });
        }

        return Ok(results);
    }
}