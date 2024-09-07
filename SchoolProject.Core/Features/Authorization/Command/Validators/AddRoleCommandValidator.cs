using FluentValidation;
using LocalizationLanguage;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Command.Models;

using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Validators
{
    public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<AddRoleCommandValidator> _localizer;

        public AddRoleCommandValidator(IAuthorizationService authorizationService, IStringLocalizer<AddRoleCommandValidator> localizer)
        {


            this._authorizationService = authorizationService;
            this._localizer = localizer;
            ApplyValidationRule();
            ApplyCusotmValidationRule();

        }

        private void ApplyCusotmValidationRule()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                  .WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull()
                  .WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);
          
           
        }

        private void ApplyValidationRule()
        {
            RuleFor(x=>x.Name)
                .MustAsync(async(key,CancellationToken)
                =>!await _authorizationService
                .IsExistRoleAsync(key))
                .WithMessage(_localizer[ShareResourcesKey.IsExist]);
        }
    }
}
