using FluentValidation;
using LocalizationLanguage;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Command.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.Resources;
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
        private readonly IStringLocalizer<ShareResources> _localizer;

        public AddRoleCommandValidator(IAuthorizationService authorizationService, IStringLocalizer<ShareResources> localizer)
        {


            this._authorizationService = authorizationService;
            this._localizer = localizer;
            ApplyValidationRule();
            ApplyCusotmValidationRule();

        }

        private void ApplyCusotmValidationRule()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty()
                  .WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull()
                  .WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);
            RuleFor(x => x.NameAr)
                .NotEmpty()
                  .WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull()
                  .WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);
           
        }

        private void ApplyValidationRule()
        {
            RuleFor(x=>x.NameEn)
                .MustAsync(async(key,CancellationToken)
                =>!await _authorizationService
                .IsExistRoleAsync(key))
                .WithMessage(_localizer[ShareResourcesKey.IsExist]);
            RuleFor(x => x.NameAr)
                .MustAsync(async (key, CancellationToken)
                => !await _authorizationService
                .IsExistRoleAsync(key))
                .WithMessage(_localizer[ShareResourcesKey.IsExist]);
        }
    }
}
