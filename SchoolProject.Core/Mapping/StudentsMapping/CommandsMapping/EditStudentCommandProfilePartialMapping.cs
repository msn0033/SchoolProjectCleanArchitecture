using AutoMapper;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile : Profile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>();
        }
    }
}
