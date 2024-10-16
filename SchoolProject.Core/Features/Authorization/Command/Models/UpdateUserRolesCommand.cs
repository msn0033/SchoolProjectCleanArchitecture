using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Models
{
    public class UpdateUserRolesCommand: UpdateUserRolesRequest, IRequest<ApiResponse<string>>
    {
    }
}
