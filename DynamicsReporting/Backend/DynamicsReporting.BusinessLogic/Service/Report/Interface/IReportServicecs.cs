using DynamicsReporting.DataAccess.Repository.Report.Interface;
using DynamicsReporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsReporting.BusinessLogic.Service.Report.Interface
{
    public interface IReportService
    {
        Task<PaginatedResult<ReportModel>> GetAllAsync(int currentPage, int pageSize);


        Task<PaginatedResult<ReportModel>> GetReportByIdAsync(int groupId, int currentPage, int pageSize);



    }
}
