using FluentValidation;
using LocalizationLanguage;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Students.Commands.Handlers;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validatiors
{
    public class SignInUserValidation : AbstractValidator<SignInUserCommand>
    {
        private readonly IStringLocalizer<SignInUserValidation> _localizer;
        private readonly SignInManager<User> _signInManager;

        public SignInUserValidation(IStringLocalizer<SignInUserValidation> localizer, SignInManager<User> signInManager)
        {
            _localizer = localizer;
            _signInManager = signInManager;
            ApplyValidationRule();
            ApplyCusotmValidationRule();
            
        }

        private void ApplyValidationRule()
        {
            var ss = _localizer[ShareResourcesKey.Must_not_be_Empty];
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null]);

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Empty])
                .NotNull().WithMessage(_localizer[ShareResourcesKey.Must_not_be_Null])
               .Length(4, 10).WithMessage(_localizer[ShareResourcesKey.Must_be_is_10_numbers]);
        }
        private void ApplyCusotmValidationRule()
        {
            //RuleFor(x => x.UserName)
            //    .MustAsync(async (key, CancellationToken)=>
            //    {

            //        var user = await _signInManager.UserManager.FindByNameAsync(key);
            //        if(user == null) return false; 
            //        return true;
            //    })
            //    .WithMessage(_localizer[ShareResourcesKey.User_Is_Not_Exist]);

            RuleFor(x => x)
               .MustAsync(async (key, CancellationToken) =>
               {

                   var user = await _signInManager.UserManager.FindByNameAsync(key.UserName);
                   if (user != null)
                   {
                       var password = await _signInManager.UserManager.CheckPasswordAsync(user, key.Password);
                       if (password) return true;
                   }
                   return false;
               })
               .WithMessage(_localizer[ShareResourcesKey.Incorrect_username_password]);



        }
    }
}
