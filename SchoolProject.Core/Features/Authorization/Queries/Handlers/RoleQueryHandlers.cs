using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
using SchoolProject.Helper.Extension;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Helper.Wrappers;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandlers : ResponseHandler
        ,IRequestHandler<GetRoleByIdQueryRequest, Response<GetRoleByIdQueryResponse>>
        ,IRequestHandler<GetRoleByNameQueryRequest, Response<GetRoleByNameQueryResponse>>
        ,IRequestHandler<GetRolesPaginatedListQuery,Response<PaginatedResult<GetRolesPaginatedListQueryResponse>>>
       
    {
        private readonly IAuthorizationService _authorization;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<RoleQueryHandlers> _localizer;

        public RoleQueryHandlers(IAuthorizationService authorization
            , IMapper mapper
            , IStringLocalizer<RoleQueryHandlers> localizer) : base(localizer)
        {
            this._authorization = authorization;
            this._mapper = mapper;
            this._localizer = localizer;
        }
        // role by id
        public async Task<Response<GetRoleByIdQueryResponse>> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var role = await _authorization.GetRoleByIdAsync(request.Id);
            if (role == null) 
                return NotFound<GetRoleByIdQueryResponse>(_localizer[ShareResourcesKey.NotFound]);
            var result = _mapper.Map<GetRoleByIdQueryResponse>(role);
            return Success(result);
        }
        // role by name
        public async Task<Response<GetRoleByNameQueryResponse>> Handle(GetRoleByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var role= await _authorization.GetRoleByNameAsync(request.SearchName!);
            if (role == null) 
                return NotFound<GetRoleByNameQueryResponse>(_localizer[ShareResourcesKey.NotFound]);
            var result=_mapper.Map<GetRoleByNameQueryResponse>(role);
            return Success(result);


        }
        // roles  paginated
        public async Task<Response<PaginatedResult<GetRolesPaginatedListQueryResponse>>> Handle(GetRolesPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var roles= await _authorization.GetAllRoles();
            if (roles == null) 
                return NotFound<PaginatedResult<GetRolesPaginatedListQueryResponse>>(_localizer[ShareResourcesKey.NotFound]);

            var mapperQuarable=_mapper.ProjectTo<GetRolesPaginatedListQueryResponse>(roles);
            var result=await mapperQuarable.ToPaginatedListAsync(request.pageNumber, request.PageSize);
            
            return Success(result);
        }
    }
}
