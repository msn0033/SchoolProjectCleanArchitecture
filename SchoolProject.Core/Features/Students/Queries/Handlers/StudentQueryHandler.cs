using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;

using SchoolProject.Data.Entities;
using SchoolProject.Helper.Extension;
using SchoolProject.Helper.Resources;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Helper.Wrappers;
using SchoolProject.Service.Interface;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
         IRequestHandler<StudentsListQuery, Response<IEnumerable<GetStudentsListQueryResponse>>>
        , IRequestHandler<StudentByIdQuery, Response<GetStudentsListQueryResponse>>
        , IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        private readonly IStringLocalizer<StudentQueryHandler> _localizer;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<StudentQueryHandler> localizer):base(localizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._localizer = localizer;
      
        }

        //GetStudents_List_withIncludeAsync
        public async Task<Response<IEnumerable<GetStudentsListQueryResponse>>> Handle(StudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListwithIncludeAsync();

            var studentsResponseMapping = _mapper.Map<IEnumerable<GetStudentsListQueryResponse>>(students);


            var plusMeta = Success(studentsResponseMapping);
            plusMeta.Meta = new { count = studentsResponseMapping.Count() };
            return plusMeta;
        }

        //GetStudentByIdWithIncludeAsync
        public async Task<Response<GetStudentsListQueryResponse>> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.id);
            if (student == null)
                return NotFound<GetStudentsListQueryResponse>(_localizer["welcome"]);
            var result = _mapper.Map<GetStudentsListQueryResponse>(student);
            return Success(result);

        }

        //paginatedResult_Include_ASQuerable_Search_Or_OrderBy
        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.Localize(e.NameAr!, e.NameEn!), e.Address!, e.Phone!, e.Department.Localize(e.NameAr!, e.NameEn!));
            
            var studentQuerable = _studentService.GetStudents_Include_List_ASQuerable_Search_Or_OrderBy(request.Search, request.OrderBy);
            // var paginatedResult = await studentQuerable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var paginatedResult = await _mapper.ProjectTo<GetStudentPaginatedListResponse>(studentQuerable).ToPaginatedListAsync(request.PageNumber,request.PageSize);
            paginatedResult.Meta = new { count = paginatedResult.Data.Count };
            return paginatedResult;
        }
    }
}
