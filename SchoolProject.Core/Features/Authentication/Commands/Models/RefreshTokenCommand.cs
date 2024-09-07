using MediatR;
using SchoolProject.Data.Result;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand:IRequest<Response<JwtAuthResult>>
    {
        public required string AccessToken { get; set; }
        public required string RefreshTokenString { get; set; }
    }
}
