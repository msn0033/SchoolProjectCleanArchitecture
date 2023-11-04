using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Data.Entities;
using SchoolProject.Helper.Extension;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentsHandlers :ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentsService _departmentservice;
        private readonly IStudentService _studentService;

        public DepartmentsHandlers(IMapper mapper ,IDepartmentsService service,IStudentService studentService)
        {
            this._mapper = mapper;
            this._departmentservice = service;
            this._studentService = studentService;
        }
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            Department result=await _departmentservice.GetDepartmentById_Include_Async(request.Id);
            if (result == null) return NotFound<GetDepartmentByIdResponse>("Not Found Item");
            var maper=_mapper.Map<GetDepartmentByIdResponse>(result);
           
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e);
             var StudentQuarableByDepartmentId = _studentService.GetStudents_By_Dipartment_Id(request.Id);
            var paginationStudentList = await StudentQuarableByDepartmentId.Select(expression).ToPaginatedListAsync(request.PageNumber,request.PageSize);
            maper.StudentList = paginationStudentList;
            return Success(maper);
           

        }
    }
}
