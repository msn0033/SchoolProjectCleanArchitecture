using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Data.Request;
using SchoolProject.Data.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Models
{
    public class UpdateUserClaimsCommand: UpdateUserClaimsRequest, IRequest<ApiResponse<string>>
    {
    }
}
