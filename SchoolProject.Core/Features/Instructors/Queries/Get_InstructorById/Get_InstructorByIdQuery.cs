using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Queries.Get_InstructorByFunctionTable
{
    public class Get_InstructorByIdQuery : IRequest<ApiResponse<InstructorsDto>>
    {
    }
}
