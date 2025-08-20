using DynamicsReporting.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IDynamicsReportingRepository
{

    Task<List<ExpandoObject>> ExecuteStoredProcedureAsync(string connectionString, string spName, Dictionary<string, object>? parameters);
    Task<IEnumerable<ExpandoObject>> ExecuteStoredProcedureAsync(string connStr, string sp, int parameter);
}

