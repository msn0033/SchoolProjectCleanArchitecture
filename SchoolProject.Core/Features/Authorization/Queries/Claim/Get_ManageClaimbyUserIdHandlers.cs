using AutoMapper;
using LocalizationLanguage;
using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Authorization.Queries.Role.Get_Roles_By_UserId;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Base;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Claim
{
    public class Get_ManageClaimbyUserIdHandlers : ApiResponseHandler
        , IRequestHandler<Get_ManageClaimbyUserIdQuery, ApiResponse<ManageUserClaimsResult>>
    {
        private readonly IAuthorizationService _authorization;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<Get_ManageClaimbyUserIdHandlers> _localizer;

        public Get_ManageClaimbyUserIdHandlers(IAuthorizationService authorization
            , IMapper mapper
            , UserManager<User> userManager
            , IStringLocalizer<Get_ManageClaimbyUserIdHandlers> localizer) : base(localizer)
        {
            _authorization = authorization;
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }

        public async Task<ApiResponse<ManageUserClaimsResult>> Handle(Get_ManageClaimbyUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return NotFound<ManageUserClaimsResult>(_localizer[ShareResourcesKey.NotFound]);

            var response = await _authorization.GetManageUserClaimsDataAsync(user);
            if (response == null)
                return NotFound<ManageUserClaimsResult>(_localizer[ShareResourcesKey.NotFound]);
            return Success(response);

        }
    }
}
