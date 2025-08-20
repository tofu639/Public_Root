using DynamicsReporting.Models;
using System.Dynamic;


public interface IDynamicsReportingService
{

    Task<PaginatedResult<ExpandoObject>> GetDynamicsReportingDataAsync(int inputPageId, int currentPage, int pageSize);



}

