using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<ApiResponse<AuthResult>>
    {
        public required string Token { get; set; }
        public required string RefreshTokenString { get; set; }
    }
}
