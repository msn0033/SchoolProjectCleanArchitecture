﻿using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Result;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandlers : ApiResponseHandler
        ,IRequestHandler<GetRoleByIdQuery, ApiResponse<GetRoleByIdQueryResponse>>
        ,IRequestHandler<GetRoleByNameQuery, ApiResponse<GetRoleByNameQueryResponse>>
        ,IRequestHandler<GetRolesPaginatedListQuery,ApiResponse<PaginatedList<GetRolesPaginatedListQueryResponse>>>
        ,IRequestHandler<ManageUserRolesQuery,ApiResponse<ManageUserRolesResult>>
   
       
    {
        private readonly IAuthorizationService _authorization;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<RoleQueryHandlers> _localizer;

        public RoleQueryHandlers(IAuthorizationService authorization
            , IMapper mapper
            ,UserManager<User> userManager
            , IStringLocalizer<RoleQueryHandlers> localizer) : base(localizer)
        {
            this._authorization = authorization;
            this._mapper = mapper;
            this._userManager = userManager;
            this._localizer = localizer;
        }
        // role by id
        public async Task<ApiResponse<GetRoleByIdQueryResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorization.GetRoleByIdAsync(request.Id);
            if (role == null) 
                return NotFound<GetRoleByIdQueryResponse>(_localizer[ShareResourcesKey.NotFound]);
            var result = _mapper.Map<GetRoleByIdQueryResponse>(role);
            return Success(result);
        }
        // role by name
        public async Task<ApiResponse<GetRoleByNameQueryResponse>> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            var role= await _authorization.GetRoleByNameAsync(request.SearchName!);
            if (role == null) 
                return NotFound<GetRoleByNameQueryResponse>(_localizer[ShareResourcesKey.NotFound]);
            var result=_mapper.Map<GetRoleByNameQueryResponse>(role);
            return Success(result);


        }
        // roles  paginated
        public async Task<ApiResponse<PaginatedList<GetRolesPaginatedListQueryResponse>>> Handle(GetRolesPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var roles= await _authorization.GetAllRolesAsync();
            if (roles == null) 
                return NotFound<PaginatedList<GetRolesPaginatedListQueryResponse>>(_localizer[ShareResourcesKey.NotFound]);

            var mapperQuarable=_mapper.ProjectTo<GetRolesPaginatedListQueryResponse>(roles);
            var result=await mapperQuarable.ToPaginatedListAsync(request.pageNumber, request.PageSize);
            
            return Success(result);
        }

        //ManageUserRoles
        public async Task<ApiResponse<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user=await _userManager.FindByIdAsync(request.UserId.ToString());
            if(user == null) return NotFound<ManageUserRolesResult>(_localizer[ShareResourcesKey.NotFound]);
            var result = await _authorization.GetManageRolesByUserIdAsync(user);
            return Success(result);
        }
    }
}
