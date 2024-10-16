using MediatR;
using SchoolProject.Core.Base.ApiResponse;

namespace SchoolProject.Core.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<ApiResponse<StudentResponse>>
    {
        public int id { get; set; }
    }
}
