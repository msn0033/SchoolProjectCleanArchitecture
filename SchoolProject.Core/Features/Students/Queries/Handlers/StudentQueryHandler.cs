using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Helper.Extension;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Helper.Wrappers;
using SchoolProject.Service.Interface;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
         IRequestHandler<StudentsListQuery, Response<IEnumerable<StudentsListQueryResponse>>>
        , IRequestHandler<StudentByIdQuery, Response<StudentsListQueryResponse>>
        , IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ShareResources> _localizer;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<ShareResources> localizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._localizer = localizer;
        }

        public async Task<Response<IEnumerable<StudentsListQueryResponse>>> Handle(StudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListwithIncludeAsync();

            var studentsResponseMapping = _mapper.Map<IEnumerable<StudentsListQueryResponse>>(students);

            return Success(studentsResponseMapping);
        }

        public async Task<Response<StudentsListQueryResponse>> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.id);
            if (student == null)
                return NotFound<StudentsListQueryResponse>(_localizer[ShareResourcesKey.NotFound]);
            var result = _mapper.Map<StudentsListQueryResponse>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.Localize(e.NameAr, e.NameEn), e.Address, e.Phone, e.Department.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentService.GetStudents_Include_List_ASQuerable_Search_Or_OrderBy(request.Search, request.OrderBy);
            var paginatedResult = await studentQuerable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedResult;
        }
    }
}
