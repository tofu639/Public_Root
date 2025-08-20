using Dapper;
  
using DynamicsReporting.ExternalService;

namespace DynamicsReporting.DataAccess.Repository.Logging
{

    public class LoggingRepository(IDatabaseConnection dbContext, Utility utility) : ILoggingRepository
    {
        private readonly IDatabaseConnection _dbContext = dbContext;
            
        private readonly Utility _utility = utility;

        public async Task<int> CreateLoggingFailAsync(LoggingFailModel log)
        {
            const string query = @"
                                        INSERT INTO LoggingFail (FunctionName, ErrorPath , FileName , ErrorMessages , InsertDate , AppName , HostName , IPAddress)
                                        VALUES (@FunctionName, @ErrorPath, @FileName , @ErrorMessages , @InsertDate , @AppName , @HostName , @IPAddress);";

            //log.InsertDate = DateTime.UtcNow.AddHours(7);
            log.HostName = Environment.MachineName;
            log.AppName = _utility.GetSection("AppName")?.ToString() ?? "DynamicsReporting";  
            log.IPAddress = _utility.GetLocalIPAddress();

            try
            {
                using var connection = _dbContext.CreateConnection();
                return await connection.QuerySingleOrDefaultAsync<int>(query, log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot Insert Log Failed to Table  : {ex.Message}");
                throw;
            }
        }
    }

}
