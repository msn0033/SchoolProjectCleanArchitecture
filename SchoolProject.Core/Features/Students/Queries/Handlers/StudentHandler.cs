using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;

using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler :ResponseHandler, IRequestHandler<GetStudentsListQuery,Response< IEnumerable<StudentsResponse>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentService studentService ,IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }
        public async Task<Response<IEnumerable<StudentsResponse>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
             var students=await _studentService.GetStudentsAsync();
            var studentsResponseMapping= _mapper.Map<IEnumerable<StudentsResponse>>(students);
            
            return Success(studentsResponseMapping);
        }
    }
}
