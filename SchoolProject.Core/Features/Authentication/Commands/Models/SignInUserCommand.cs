using MediatR;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SignInUserCommand:IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
