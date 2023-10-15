using AutoMapper;

namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentMapping();
            addStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
