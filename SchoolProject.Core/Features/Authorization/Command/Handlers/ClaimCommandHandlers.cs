using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Authorization.Command.Models;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Handlers
{
    public class ClaimCommandHandlers : ApiResponseHandler
        , IRequestHandler<UpdateUserClaimsCommand, ApiResponse<string>>
    {
        private readonly IAuthorizationService _authorization;
        private readonly IStringLocalizer<ClaimCommandHandlers> _localizer;

        public ClaimCommandHandlers(IAuthorizationService authorization, IStringLocalizer<ClaimCommandHandlers> localizer) : base(localizer)
        {
            this._authorization = authorization;
            this._localizer = localizer;
        }

        public async Task<ApiResponse<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var response = await _authorization.UpdateUserClaimsAsync(request);
            switch (response)
            {
                case "UserIsNull":
                    return NotFound<string>(_localizer[ShareResourcesKey.NotFoundUser]);
                case "FailedToRemoveOldClaimsByUser":
                   return BadRequest<string>(_localizer[ShareResourcesKey.FailedToRemoveOldClaimsByUser]);
                   
                case "FailedToAddNewClaims":
                    return BadRequest<string>(_localizer[ShareResourcesKey.FailedToAddNewClaims]);
                case "Success":
                    return Success<string>(_localizer[ShareResourcesKey.Add_Successfully]);
                default:
                    return Failed<string>(_localizer[ShareResourcesKey.FailedToUpdateClaims]);
                    
            }
        }
    }
}
