using FluentValidation;
using LocalizationLanguage;
using Microsoft.Extensions.Localization;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Role.Create
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<CreateRoleValidator> _localizer;

        public CreateRoleValidator(IAuthorizationService authorizationService, IStringLocalizer<CreateRoleValidator> localizer)
        {


            _authorizationService = authorizationService;
            _localizer = localizer;
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
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken)
                => !await _authorizationService
                .IsExistRoleAsync(key))
                .WithMessage(_localizer[ShareResourcesKey.IsExist]);
        }
    }
}
