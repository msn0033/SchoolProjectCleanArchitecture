using MediatR;
using SchoolProject.Core.Base.ApiResponse;

namespace SchoolProject.Core.Features.Students.Commands.Update
{
    public class UpdateStudentCommand : IRequest<ApiResponse<string>>
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
