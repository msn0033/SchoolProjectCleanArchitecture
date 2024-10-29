using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.SignIn
{
    public class SignInUserCommand : IRequest<ApiResponse<AuthResult>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
