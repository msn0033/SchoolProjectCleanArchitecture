using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentCommandValidation : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;

        public EditStudentCommandValidation(IStudentService studentService)
        {
            this._studentService = studentService;
            ApplyValidationRule();
            ApplyCusotmValidationRule();

        }
        private void ApplyValidationRule()
        {
            RuleFor(x => x.Name)

                .NotEmpty().WithMessage(@"{PropertyName} Must not be Empty")
                .NotNull().WithMessage(@" {PropertyName} Must not be Null")
                .MaximumLength(10).WithMessage(@"{PropertyName} Max Lenght is 10");
            RuleFor(x => x.Address)
               .NotEmpty().WithMessage(@"{PropertyName} Must not be Empty")
               .NotNull().WithMessage(@"{PropertyName} Must not be Null")
               .MaximumLength(10).WithMessage(@"{PropertyName} Max Lenght is 10");
        }
        private void ApplyCusotmValidationRule()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExculdeSelf(key, model.Id))
                .WithMessage($" الاسم موجود مسبقاً في عنصر اخر");



        }
    }
}
