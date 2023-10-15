using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentCommandValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;

        public AddStudentCommandValidation( IStudentService studentService)
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
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage("الاسم موجود مسبقاً");

        }
    }
}
