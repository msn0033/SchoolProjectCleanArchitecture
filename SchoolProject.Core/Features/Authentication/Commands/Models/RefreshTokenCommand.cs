using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Data.Result;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand:IRequest<ApiResponse<JwtAuthResult>>
    {
        public required string AccessToken { get; set; }
        public required string RefreshTokenString { get; set; }
    }
}
