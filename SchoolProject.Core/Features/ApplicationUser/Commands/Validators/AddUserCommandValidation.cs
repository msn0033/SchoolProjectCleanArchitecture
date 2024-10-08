﻿using FluentValidation;
using LocalizationLanguage;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;



namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class AddUserCommandValidation:AbstractValidator<AddUserCommand>
    {
        private readonly IStringLocalizer<AddUserCommandValidation> _localizer;

        public AddUserCommandValidation(IStringLocalizer<AddUserCommandValidation> localizer)
        {
            _localizer = localizer;
            ApplyValidationRule();
            //ApplyCustomValidationRule();
           
        }
        private void ApplyValidationRule()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
               .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);
               

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null])
                .Equal(x => x.PasswordConfirm)
                .WithMessage(_localizer[ShareResourcesKey.password_does_not_match]);
        }
        private void ApplyCustomValidationRule()
        {
           
        }

    
    }
}
