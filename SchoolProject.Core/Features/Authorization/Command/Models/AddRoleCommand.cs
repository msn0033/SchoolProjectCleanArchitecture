using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Models
{
    public class AddRoleCommand:IRequest<ApiResponse<string>>
    {
        public required string Name { get; set; } 
    }
}
