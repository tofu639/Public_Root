﻿using Azure;
using Dapper;
using DynamicsReporting.DataAccess.Repository.Group.Interface;
using DynamicsReporting.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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

            var sql = "EXEC usp_GetAllGroup";
            var allResults = (await _db.QueryAsync<GroupModel>(sql)).ToList();
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
            var sql = "EXEC usp_GroupReportByGroupId @i_GroupID";
            var allResults = (await _db.QueryAsync<GroupReportModel>(sql, new { i_GroupID = groupId })).ToList();

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

        public async Task<PaginatedResult<GroupReportUseModel>> GetGroupReportByUserIdAsync(string userID, int currentPage, int pageSize)
        {
            var response = new PaginatedResult<GroupReportUseModel>();
            var sql = "EXEC usp_UserGroupReportByUserId @i_UserID";
            var allResults = (await _db.QueryAsync<GroupReportUseModel>(sql, new { i_UserID = userID })).ToList();

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
