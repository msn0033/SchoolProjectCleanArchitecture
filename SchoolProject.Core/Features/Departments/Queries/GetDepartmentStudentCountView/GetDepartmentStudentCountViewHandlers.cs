using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Departments.Queries.GetDepartmentById;

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

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCountView
{
    public class GetDepartment_ById_StudentCountProcHandlers :ApiResponseHandler, 
 
        IRequestHandler<GetDepartmentStudentCountViewQuery,ApiResponse<List<GetDepartmentStudentCountViewResponse>>>

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
        //View
        public async Task<ApiResponse<List<GetDepartmentStudentCountViewResponse>>> Handle(GetDepartmentStudentCountViewQuery request, CancellationToken cancellationToken)
        {
            var viewDepartment=await _departmentservice.GetDepartmentStudentCountViewAsync();
            if (viewDepartment == null) return NotFound<List<GetDepartmentStudentCountViewResponse>>(_localizer[ShareResourcesKey.NotFound]);
            var maper=_mapper.Map<List<GetDepartmentStudentCountViewResponse>>(viewDepartment);
            var x=Success(maper);
            x.Meta = new { count = maper.Count() };
            return x;
        }
 
    }
}

