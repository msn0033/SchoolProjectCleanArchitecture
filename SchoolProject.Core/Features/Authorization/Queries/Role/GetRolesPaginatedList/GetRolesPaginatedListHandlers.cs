using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Authorization.Queries.Claim;
using SchoolProject.Data.Entities.Identity;

using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolProject.Core.Features.Authorization.Queries.Role.GetRolesPaginatedList
{
    public class GetRolesPaginatedListHandlers : ApiResponseHandler 
        , IRequestHandler<GetRolesPaginatedListQuery, ApiResponse<PaginatedList<RoleResponse>>>



    {
        private readonly IAuthorizationService _authorization;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<GetRolesPaginatedListHandlers> _localizer;

        public GetRolesPaginatedListHandlers(IAuthorizationService authorization
            , IMapper mapper
            , UserManager<User> userManager
            , IStringLocalizer<GetRolesPaginatedListHandlers> localizer) : base(localizer)
        {
            _authorization = authorization;
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }
     
      
        // roles  paginated
        public async Task<ApiResponse<PaginatedList<RoleResponse>>> Handle(GetRolesPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorization.GetAllRolesAsync();
            if (roles == null)
                return NotFound<PaginatedList<RoleResponse>>(_localizer[ShareResourcesKey.NotFound]);

            var mapperQuarable = _mapper.ProjectTo<RoleResponse>(roles);
            var result = await mapperQuarable.ToPaginatedListAsync(request.pageNumber, request.PageSize);

            return Success(result);
        }

      
    }
}
