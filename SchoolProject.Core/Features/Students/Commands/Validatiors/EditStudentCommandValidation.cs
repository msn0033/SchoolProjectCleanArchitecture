using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentCommandValidation : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<ShareResources> _localizer;

        public EditStudentCommandValidation(IStudentService studentService, IStringLocalizer<ShareResources> localizer)
        {
            this._studentService = studentService;
            this._localizer = localizer;
            ApplyValidationRule();
            ApplyCusotmValidationRule();

        }
        private void ApplyValidationRule()
        {
            RuleFor(x => x.NameEn)
           .NotEmpty().WithMessage(_localizer["Item Must not be Empty"])
           .NotNull().WithMessage(_localizer["Must not be Null"])
           .MaximumLength(10).WithMessage(_localizer["Max Lenght is 10"]);

            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer["Item Must not be Empty"])
                .NotNull().WithMessage(_localizer["Must not be Null"])
                .MaximumLength(10).WithMessage(_localizer["Max Lenght is 10"]);
            RuleFor(x => x.Address)
               .NotEmpty().WithMessage(_localizer["Item Must not be Empty"])
               .NotNull().WithMessage(_localizer["Must not be Null"])
               .MaximumLength(10).WithMessage(_localizer["Max Lenght is 10"]);

            RuleFor(x => x.Phone)
               .NotEmpty().WithMessage(_localizer["Item Must not be Empty"])
               .NotNull().WithMessage(_localizer["Must not be Null"])
               .Length(10, 10).WithMessage(_localizer["Must be is 10 numbers"]);
        }
        private void ApplyCusotmValidationRule()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExculdeSelf(key, model.Id))
                .WithMessage($" الاسم موجود مسبقاً في عنصر اخر");
            RuleFor(x => x.NameAr)
               .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExculdeSelf(key, model.Id))
               .WithMessage($" الاسم موجود مسبقاً في عنصر اخر");



        }
    }
}
