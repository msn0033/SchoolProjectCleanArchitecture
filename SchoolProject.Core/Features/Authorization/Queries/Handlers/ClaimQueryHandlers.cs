using AutoMapper;
using LocalizationLanguage;
using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
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
    public  class ClaimQueryHandlers : ApiResponseHandler
        , IRequestHandler<ManageUserClaimQuery,ApiResponse<ManageUserClaimsResult>>
    {
        private readonly IAuthorizationService _authorization;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<RoleQueryHandlers> _localizer;

        public ClaimQueryHandlers(IAuthorizationService authorization
            , IMapper mapper
            , UserManager<User> userManager
            , IStringLocalizer<RoleQueryHandlers> localizer) : base(localizer)
        {
            this._authorization = authorization;
            this._mapper = mapper;
            this._userManager = userManager;
            this._localizer = localizer;
        }

        public async Task<ApiResponse<ManageUserClaimsResult>> Handle(ManageUserClaimQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) 
                return NotFound<ManageUserClaimsResult>(_localizer[ShareResourcesKey.NotFound]);

            var response = await _authorization.GetManageUserClaimsDataAsync(user);
            if(response == null)
                return NotFound<ManageUserClaimsResult>(_localizer[ShareResourcesKey.NotFound]);
            return Success(response);

        }
    }
}
