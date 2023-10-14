using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class StudentCommandValidation : AbstractValidator<StudentCommandRequest>
    {
        public StudentCommandValidation()
        {
            ApplyValidationRule();   
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
    }
}
