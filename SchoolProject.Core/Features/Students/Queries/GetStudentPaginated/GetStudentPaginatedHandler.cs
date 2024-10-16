using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using static SchoolProject.Data.Permission.Permission;

namespace SchoolProject.Core.Features.Students.Queries.GetStudentPaginated
{
    public class GetStudentPaginatedHandler : ApiResponseHandler,
                          IRequestHandler<GetStudentPaginatedQuery, PaginatedList<StudentResponse>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        private readonly IStringLocalizer<GetStudentPaginatedHandler> _localizer;

        public GetStudentPaginatedHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<GetStudentPaginatedHandler> localizer):base(localizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._localizer = localizer;
      
        }


        //paginatedResult_Include_ASQuerable_Search_Or_OrderBy
        public async Task<PaginatedList<StudentResponse>> Handle(GetStudentPaginatedQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.Localize(e.NameAr!, e.NameEn!), e.Address!, e.Phone!, e.Department.Localize(e.NameAr!, e.NameEn!));
            
            var studentQuerable = _studentService.GetStudents_Include_List_ASQuerable_Search_Or_OrderBy(request.Search, request.OrderBy);
            // var paginatedResult = await studentQuerable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var paginatedResult = await _mapper.ProjectTo<StudentResponse>(studentQuerable).ToPaginatedListAsync(request.PageNumber,request.PageSize);
            paginatedResult.Meta = new { count = paginatedResult.Data.Count };
            return paginatedResult;
        }
    }
}
