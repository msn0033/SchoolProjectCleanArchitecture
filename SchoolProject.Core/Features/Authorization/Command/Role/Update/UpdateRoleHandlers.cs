using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Authorization.Command.Role.Create;
using SchoolProject.Core.Features.Authorization.Command.Role.Update;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Role
{
    public class UpdateRoleHandlers : ApiResponseHandler  
        , IRequestHandler<UpdateRolesCommand, ApiResponse<string>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<UpdateRoleHandlers> _Localizer;

        public UpdateRoleHandlers(IAuthorizationService authorizationService
            , IStringLocalizer<UpdateRoleHandlers> stringLocalizer) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
            _Localizer = stringLocalizer;
        }

       
        //update Role
        public async Task<ApiResponse<string>> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            var reslut = await _authorizationService.UpdateManageRolesByUserIdAsync(request);
            return Success(reslut);
        }
    }
}
