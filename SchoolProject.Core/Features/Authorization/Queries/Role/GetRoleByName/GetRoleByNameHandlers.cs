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

namespace SchoolProject.Core.Features.Authorization.Queries.Role.GetRoleByName
{
    public class GetRoleByNameHandlers : ApiResponseHandler
       
        , IRequestHandler<GetRoleByNameQuery, ApiResponse<RoleResponse>>



    {
        private readonly IAuthorizationService _authorization;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<GetRoleByNameHandlers> _localizer;

        public GetRoleByNameHandlers(IAuthorizationService authorization
            , IMapper mapper
            , UserManager<User> userManager
            , IStringLocalizer<GetRoleByNameHandlers> localizer) : base(localizer)
        {
            _authorization = authorization;
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }
     
        // role by name
        public async Task<ApiResponse<RoleResponse>> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorization.GetRoleByNameAsync(request.SearchName!);
            if (role == null)
                return NotFound<RoleResponse>(_localizer[ShareResourcesKey.NotFound]);
            var result = _mapper.Map<RoleResponse>(role);
            return Success(result);


        }
       
    }
}
