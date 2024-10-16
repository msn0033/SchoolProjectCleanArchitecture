using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Queries.Get_All_Instructor
{
    public class Get_All_Instructor_Query_Handler:ApiResponseHandler,IRequestHandler<Get_All_Instructor_Query,ApiResponse<List<InstructorsDto>>>
    {
        private readonly IInstructorService _instructorService;
        private readonly IStringLocalizer<Get_All_Instructor_Query_Handler> _localizer;

        public Get_All_Instructor_Query_Handler(IInstructorService instructorService,IStringLocalizer<Get_All_Instructor_Query_Handler> localizer):base(localizer)
        {
            this._instructorService = instructorService;
            this._localizer = localizer;
        }

        Task<ApiResponse<List<InstructorsDto>>> IRequestHandler<Get_All_Instructor_Query, ApiResponse<List<InstructorsDto>>>.Handle(Get_All_Instructor_Query request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
