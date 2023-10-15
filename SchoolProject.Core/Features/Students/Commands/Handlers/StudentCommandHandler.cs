﻿using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //maper
            var studentmapping = _mapper.Map<Student>(request);
            //add to database
            var result = await _studentService.AddStudentAsync(studentmapping);

            //check is Exist
            if (result.Equals("Exist")) return UnprocessableEntity<string>("Name is Exist");

            //check add is ok
            else if (result == "Success") return Created("add Successfully");


            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check item is exist
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            //return not found if not exist
            if (student == null) return NotFound<string>("item not Found");
            //mapping
            var studentMapping = _mapper.Map<Student>(request);
            //service Edit
            string result = await _studentService.EditStudentAsync(studentMapping);
            //return Success
            return Created<string>(result);
        }
    }
}
