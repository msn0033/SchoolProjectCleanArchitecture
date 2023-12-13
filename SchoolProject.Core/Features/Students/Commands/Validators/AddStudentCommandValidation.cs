using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Helper.Resources;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentCommandValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentsService _departmentsService;
        private readonly IStringLocalizer<ShareResources> _localizer;

        public AddStudentCommandValidation(IStudentService studentService, IDepartmentsService departmentsService, IStringLocalizer<ShareResources> localizer)
        {
            this._studentService = studentService;
            this._departmentsService = departmentsService;
            this._localizer = localizer;
            ApplyValidationRule();
            ApplyCusotmValidationRule();

        }
        private void ApplyValidationRule()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);


            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);


            RuleFor(x => x.Phone)
               .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null])
               .Length(10, 10).WithMessage(_localizer[ShareResourcesKey.Must_be_is_10_numbers]);
        }
        private void ApplyCusotmValidationRule()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage(_localizer[ShareResourcesKey.IsExist]);

            RuleFor(x => x.NameAr)
             .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
             .WithMessage(_localizer[ShareResourcesKey.IsExist]);

            RuleFor(x => x.DepartmentId)
                .MustAsync(async (key, cancellationToken) => await _departmentsService.IsDepartmentIdIExistAsync(key))
                .WithMessage(_localizer[ShareResourcesKey.NotFound]);

        }
    }
}
