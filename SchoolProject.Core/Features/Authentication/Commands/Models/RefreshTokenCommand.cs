using MediatR;
using SchoolProject.Helper.ModelsHelper;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand:IRequest<Response<JwtAuthResponse>>
    {
        public required string AccessToken { get; set; }
        public required string RefreshTokenString { get; set; }
    }
}
