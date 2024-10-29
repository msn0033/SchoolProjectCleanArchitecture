using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Departments.Queries.GetDepartmentById;

using SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCountView;

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

namespace SchoolProject.Core.Features.Departments.Queries.GetById_By_StudentCountProc
{
    public class GetDepartment_ById_StudentCountProcHandlers :ApiResponseHandler, 

        IRequestHandler<GetDepartment_ById_StudentCountProcQuery, ApiResponse<GetDepartment_ById_StudentCountProcResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentsService _departmentservice;
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<GetDepartment_ById_StudentCountProcHandlers> _localizer;

        public GetDepartment_ById_StudentCountProcHandlers(IMapper mapper ,IDepartmentsService service,IStudentService studentService ,IStringLocalizer<GetDepartment_ById_StudentCountProcHandlers> localizer):base(localizer)
        {
            this._mapper = mapper;
            this._departmentservice = service;
            this._studentService = studentService;
            this._localizer = localizer;
        }

   
        //Procedure 
        public async Task<ApiResponse<GetDepartment_ById_StudentCountProcResponse>> Handle(GetDepartment_ById_StudentCountProcQuery request, CancellationToken cancellationToken)
        {
            var paramater = _mapper.Map<DepartmentStudentCountProcParamater>(request);
            var department=await _departmentservice.GetDepartmentStudentCountProcAsync(paramater);
            var mapper=_mapper.Map<GetDepartment_ById_StudentCountProcResponse>(department.FirstOrDefault());
            return Success(mapper);
           
        }
    }
}

