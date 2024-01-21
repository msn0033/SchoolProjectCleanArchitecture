using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Command.Models;
using SchoolProject.Data.DTOs;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Handlers
{
    public class RoleCommandHandlers :ResponseHandler
        ,IRequestHandler<AddRoleCommand, Response<string>>
        ,IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<RoleCommandHandlers> _Localizer;

        public RoleCommandHandlers(IAuthorizationService authorizationService
            ,IStringLocalizer<RoleCommandHandlers> stringLocalizer):base(stringLocalizer)
        {
            this._authorizationService = authorizationService;
            this._Localizer = stringLocalizer;
        }

        //add Role
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _authorizationService.AddRoleAsync(request.Name))
                return Created<string>(_Localizer[ShareResourcesKey.Created]);
                    return BadRequest<string>(_Localizer[ShareResourcesKey.Failed]);
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var reslut = await _authorizationService.UpdateUserRolesAsync(request);
            return Success(reslut);
        }
    }
}
