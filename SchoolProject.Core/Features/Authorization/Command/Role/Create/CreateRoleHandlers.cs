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
    public class CreateRoleHandlers : ApiResponseHandler
        , IRequestHandler<CreateRoleCommand, ApiResponse<string>>
       
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<CreateRoleHandlers> _Localizer;

        public CreateRoleHandlers(IAuthorizationService authorizationService
            , IStringLocalizer<CreateRoleHandlers> stringLocalizer) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
            _Localizer = stringLocalizer;
        }

        //add Role
        public async Task<ApiResponse<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _authorizationService.AddRoleAsync(request.Name))
                return Created<string>(_Localizer[ShareResourcesKey.Created]);
            return BadRequest<string>(_Localizer[ShareResourcesKey.Failed]);
        }
       
    }
}
