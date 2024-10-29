using FluentValidation;
using LocalizationLanguage;
using Microsoft.Extensions.Localization;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Create
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        private readonly IStringLocalizer<CreateUserValidation> _localizer;

        public CreateUserValidation(IStringLocalizer<CreateUserValidation> localizer)
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
