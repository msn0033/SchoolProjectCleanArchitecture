using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCountView;
using SchoolProject.Core.Features.Students;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Procedures;


using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdHandlers : ApiResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, ApiResponse<GetDepartmentByIdResponse>>
      
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentsService _departmentservice;
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<GetDepartmentByIdHandlers> _localizer;

        public GetDepartmentByIdHandlers(IMapper mapper, IDepartmentsService service, IStudentService studentService, IStringLocalizer<GetDepartmentByIdHandlers> localizer) : base(localizer)
        {
            _mapper = mapper;
            _departmentservice = service;
            _studentService = studentService;
            _localizer = localizer;
        }
        //ById
        public async Task<ApiResponse<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            Department DepartmentById = await _departmentservice.GetDepartmentById_Include_Async(request.Id);
            if (DepartmentById == null) return NotFound<GetDepartmentByIdResponse>("Not Found Item");
            var maper = _mapper.Map<GetDepartmentByIdResponse>(DepartmentById);

            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e);
            var StudentQuarableByDepartmentId = _studentService.GetStudents_By_Dipartment_Id(request.Id);
            var paginationStudentList = await StudentQuarableByDepartmentId.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            maper.StudentList = paginationStudentList;
            return Success(maper);


        }
      
    }
}

