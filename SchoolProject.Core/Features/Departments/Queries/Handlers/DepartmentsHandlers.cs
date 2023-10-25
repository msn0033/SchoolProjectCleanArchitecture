using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Data.Entities;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentsHandlers :ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentsService _service;
        

        public DepartmentsHandlers(IMapper mapper ,IDepartmentsService service)
        {
            this._mapper = mapper;
            this._service = service;
        }
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result=await _service.GetDepartmentById_Include(request.Id);
            if (result == null) return NotFound<GetDepartmentByIdResponse>("Not Found Item");
            var maper=_mapper.Map<GetDepartmentByIdResponse>(result);
            return Success(maper);
            
        }
    }
}
