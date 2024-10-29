using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Claim.Update
{
    public class ClaimHandlers : ApiResponseHandler
        , IRequestHandler<UpdateClaimsCommand, ApiResponse<string>>
    {
        private readonly IAuthorizationService _authorization;
        private readonly IStringLocalizer<ClaimHandlers> _localizer;

        public ClaimHandlers(IAuthorizationService authorization, IStringLocalizer<ClaimHandlers> localizer) : base(localizer)
        {
            _authorization = authorization;
            _localizer = localizer;
        }

        public async Task<ApiResponse<string>> Handle(UpdateClaimsCommand request, CancellationToken cancellationToken)
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
