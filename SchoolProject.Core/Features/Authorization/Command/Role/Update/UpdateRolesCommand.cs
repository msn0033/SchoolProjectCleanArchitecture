using MediatR;
using SchoolProject.Core.Base.ApiResponse;

using SchoolProject.Service.Base.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Role.Update
{
    public class UpdateRolesCommand : UpdateUserRolesRequest, IRequest<ApiResponse<string>>
    {
    }
}
