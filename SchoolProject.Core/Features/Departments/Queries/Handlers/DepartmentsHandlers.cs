﻿using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Core.Features.Students.Commands.Handlers;
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
    public class DepartmentsHandlers :ResponseHandler, 
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentStudentCountQuery,Response<List<GetDepartmentStudentCountResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentsService _departmentservice;
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<DepartmentsHandlers> _localizer;

        public DepartmentsHandlers(IMapper mapper ,IDepartmentsService service,IStudentService studentService ,IStringLocalizer<DepartmentsHandlers> localizer):base(localizer)
        {
            this._mapper = mapper;
            this._departmentservice = service;
            this._studentService = studentService;
            this._localizer = localizer;
        }
        //ById
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            Department DepartmentById = await _departmentservice.GetDepartmentById_Include_Async(request.Id);
            if (DepartmentById == null) return NotFound<GetDepartmentByIdResponse>("Not Found Item");
            var maper=_mapper.Map<GetDepartmentByIdResponse>(DepartmentById);
           
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e);
             var StudentQuarableByDepartmentId = _studentService.GetStudents_By_Dipartment_Id(request.Id);
            var paginationStudentList = await StudentQuarableByDepartmentId.Select(expression).ToPaginatedListAsync(request.PageNumber,request.PageSize);
            maper.StudentList = paginationStudentList;
            return Success(maper);
           

        }
        //View
        public async Task<Response<List<GetDepartmentStudentCountResponse>>> Handle(GetDepartmentStudentCountQuery request, CancellationToken cancellationToken)
        {
            var viewDepartment=await _departmentservice.GetDepartmentsViewStudentQountAsync();
            if (viewDepartment == null) return NotFound<List<GetDepartmentStudentCountResponse>>(_localizer[ShareResourcesKey.NotFound]);
            var maper=_mapper.Map<List<GetDepartmentStudentCountResponse>>(viewDepartment);
            var x=Success(maper);
            x.Meta = new { count = maper.Count() };
            return x;
        }
    }
}

