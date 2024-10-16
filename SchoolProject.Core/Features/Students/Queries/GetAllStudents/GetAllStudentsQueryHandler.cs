using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using static SchoolProject.Data.Permission.Permission;

namespace SchoolProject.Core.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : ApiResponseHandler,
         IRequestHandler<GetAllStudentsQuery, ApiResponse<List<StudentResponse>>>


    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        private readonly IStringLocalizer<GetAllStudentsQueryHandler> _localizer;

        public GetAllStudentsQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<GetAllStudentsQueryHandler> localizer):base(localizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._localizer = localizer;
      
        }

        //GetStudents_List_withIncludeAsync
        public async Task<ApiResponse<List<StudentResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListwithIncludeAsync();
            if (students == null)
                return NotFound<List<StudentResponse>> (_localizer[ShareResourcesKey.NotFound]);

            var studentsResponseMapping = _mapper.Map<List<StudentResponse>>(students);
            var plusMeta = Success(studentsResponseMapping);
            plusMeta.Meta = new { count = studentsResponseMapping.Count() };
            return plusMeta;
        }

       
    }
}
