using AutoMapper;

namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdQueryPartialMapping();
            GetStudentPaginatedListQuery_Partial_Mapping();
            addStudentCommandMapping();
            EditStudentCommandMapping();
            
        }
    }
}
