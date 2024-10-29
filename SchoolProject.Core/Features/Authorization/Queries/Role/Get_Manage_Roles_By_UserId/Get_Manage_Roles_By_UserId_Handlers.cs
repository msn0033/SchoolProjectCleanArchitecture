using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Authorization.Queries.Role.Get_Roles_By_UserId;
using SchoolProject.Data.Entities.Identity;

using SchoolProject.Service.Base;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Role.Get_Manage_Roles_By_UserId
{
    public class Get_Manage_Roles_By_UserId_Handlers : ApiResponseHandler

        , IRequestHandler<Get_Manage_Roles_By_UserId_Query, ApiResponse<ManageUserRolesResult>>


    {
        private readonly IAuthorizationService _authorization;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<Get_Manage_Roles_By_UserId_Handlers> _localizer;

        public Get_Manage_Roles_By_UserId_Handlers(IAuthorizationService authorization
            , IMapper mapper
            , UserManager<User> userManager
            , IStringLocalizer<Get_Manage_Roles_By_UserId_Handlers> localizer) : base(localizer)
        {
            _authorization = authorization;
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }

      
        //ManageUserRoles
        public async Task<ApiResponse<ManageUserRolesResult>> Handle(Get_Manage_Roles_By_UserId_Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserRolesResult>(_localizer[ShareResourcesKey.NotFound]);
            var result = await _authorization.GetManageRolesByUserIdAsync(user);
            return Success(result);
        }
    }
}
