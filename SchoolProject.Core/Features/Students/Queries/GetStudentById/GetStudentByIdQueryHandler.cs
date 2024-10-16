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

namespace SchoolProject.Core.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : ApiResponseHandler,
                   IRequestHandler<GetStudentByIdQuery, ApiResponse<StudentResponse>>


    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        private readonly IStringLocalizer<GetStudentByIdQueryHandler> _localizer;

        public GetStudentByIdQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<GetStudentByIdQueryHandler> localizer):base(localizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._localizer = localizer;
      
        }


        //GetStudentByIdWithIncludeAsync
        public async Task<ApiResponse<StudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.id);
            if (student == null)
                return NotFound<StudentResponse>(_localizer[ShareResourcesKey.NotFound]);
            var result = _mapper.Map<StudentResponse>(student);
            return Success(result);

        }

    }
}
