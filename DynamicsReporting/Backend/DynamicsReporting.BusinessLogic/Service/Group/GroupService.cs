﻿using DynamicsReporting.ExternalService.Service.Group.Interface;
using DynamicsReporting.DataAccess.Repository.Group.Interface;
using DynamicsReporting.Models;

namespace DynamicsReporting.ExternalService.Service.Group
{
    internal class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<PaginatedResult<GroupModel>> GetAllAsync(int currentPage, int pageSize)
        {
            return await _groupRepository.GetAllAsync(currentPage, pageSize);
        }

        public async Task<PaginatedResult<GroupReportModel>> GetReportByGroupIdAsync(int groupId, int currentPage, int pageSize)
        {
            return await _groupRepository.GetReportByGroupIdAsync(groupId, currentPage, pageSize);
        }


        public async Task<PaginatedResult<GroupReportUseModel>> GetGroupReportByUserIdAsync(string userID, int currentPage, int pageSize)

        {
            return await _groupRepository.GetGroupReportByUserIdAsync(userID, currentPage, pageSize);
        }
    }
}
