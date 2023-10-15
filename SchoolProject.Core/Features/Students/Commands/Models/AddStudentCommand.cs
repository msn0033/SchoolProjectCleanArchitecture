using MediatR;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand:IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } =string.Empty;

        public string Phone { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
