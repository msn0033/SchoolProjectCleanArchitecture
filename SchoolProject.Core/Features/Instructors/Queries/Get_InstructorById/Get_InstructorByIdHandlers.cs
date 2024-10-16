using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Queries.Get_InstructorByFunctionTable
{
    public class Get_InstructorByIdHandlers : ApiResponseHandler,IRequestHandler<Get_InstructorByIdQuery,ApiResponse<InstructorsDto>>
    {
        private readonly IInstructorService _instructorService;
        private readonly IStringLocalizer<Get_InstructorByIdHandlers> _localizer;

        public Get_InstructorByIdHandlers( IInstructorService instructorService,IStringLocalizer<Get_InstructorByIdHandlers> localizer):base(localizer)
        {
            this._instructorService = instructorService;
            this._localizer = localizer;
        }

        public Task<ApiResponse<InstructorsDto>> Handle(Get_InstructorByIdQuery request, CancellationToken cancellationToken)
        {
            //DOTO: get instructorById
            return null;
        }
    }




}
