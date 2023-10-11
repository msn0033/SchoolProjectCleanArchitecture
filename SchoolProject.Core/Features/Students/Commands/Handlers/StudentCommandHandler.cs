using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<StudentCommandRequest, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService,IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }
        public async Task<Response<string>> Handle(StudentCommandRequest request, CancellationToken cancellationToken)
        {
            //maper
            var studentmapping=_mapper.Map<Student>(request);
            //add to database
             var result=await _studentService.AddStudentAsync(studentmapping);

            //check is Exist
            if (result.Equals("Exist")) return UnprocessableEntity<string>("Name is Exist");
            
            //check add is ok
            else if (result == "Success") return Created("add Successfully");
         

            return BadRequest<string>();
        }
    }
}
