using Dapper;
using DynamicsReporting.DataAccess.Repository.Group.Interface;
using DynamicsReporting.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsReporting.DataAccess.Repository.Group
{
    internal class GroupRepository : IGroupRepository
    {


        private readonly IDbConnection _db;

        public GroupRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("APPConn"));
        }


        public async Task<PaginatedResult<GroupModel>> GetAllAsync(int currentPage, int pageSize)
        {
            var response = new PaginatedResult<GroupModel>();
            List<GroupModel> allResults = new();



            var sql = "EXEC usp_GetAllGroup";
            allResults = (await _db.QueryAsync<GroupModel>(sql)).ToList();
            var pagedData = allResults
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            response.Data = pagedData;
            response.TotalCount = allResults.Count;
            response.Pagination = new Pagination
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalRecords = allResults.Count
            };


            return response;
        }


        public async Task<PaginatedResult<GroupReportModel>> GetReportByGroupIdAsync(int groupId, int currentPage, int pageSize)
        {
            var response = new PaginatedResult<GroupReportModel>();
            List<GroupReportModel> allResults = new();


            var sql = "EXEC usp_GroupReportByGroupId @i_GroupID";
            allResults = (await _db.QueryAsync<GroupReportModel>(sql, new { i_GroupID = groupId })).ToList();
            var pagedData = allResults
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            response.Data = pagedData;
            response.TotalCount = allResults.Count;
            response.Pagination = new Pagination
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalRecords = allResults.Count
            };


            return response;


        }





    }
}
