using Dapper;
using DynamicsReporting.DataAccess.Repository.User.Interface;
using DynamicsReporting.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DynamicsReporting.DataAccess.Repository.User
{
    internal class UserRepository : IUserRepository
    {

        private readonly IDbConnection _db;

        public UserRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("APPConn"));
        }






        public async Task<PaginatedResult<UserModel>> GetAllAsync(int currentPage, int pageSize)
        {
            var response = new PaginatedResult<UserModel>();
            List<UserModel> allResults = new();



            var sql = "EXEC usp_GetAllUsers ";
            allResults = (await _db.QueryAsync<UserModel>(sql)).ToList();
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

        public async Task<UserModel> GetByUserNameAsync(string userName)
        {
            var sql = "EXEC usp_GetUserByName @i_UserName";
            return await _db.QueryFirstOrDefaultAsync<UserModel>(sql, new { i_UserName = userName });
        }


        public async Task<PaginatedResult<UserGroupReportModel>> GroupReportByUserIdAsync(int userId, int currentPage, int pageSize)
        {
            var response = new PaginatedResult<UserGroupReportModel>();
            List<UserGroupReportModel> allResults = new();


            var sql = "EXEC usp_GroupReportByUserId @i_UserID";
            allResults = (await _db.QueryAsync<UserGroupReportModel>(sql, new { i_UserID = userId })).ToList();
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
