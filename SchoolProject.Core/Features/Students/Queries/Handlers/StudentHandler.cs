using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.Data;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : IRequestHandler<GetStudentsListQuery, IEnumerable<Student>>
    {
        private readonly IStudentService _studentService;

        public StudentHandler(IStudentService studentService)
        {
            this._studentService = studentService;
        }
        public async Task<IEnumerable<Student>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
           return  await _studentService.GetStudentsAsync();
        }
    }
}
