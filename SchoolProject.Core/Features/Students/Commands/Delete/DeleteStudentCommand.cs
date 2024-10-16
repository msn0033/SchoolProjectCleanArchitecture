using MediatR;
using SchoolProject.Core.Base.ApiResponse;

namespace SchoolProject.Core.Features.Students.Commands.Delete
{
    public class DeleteStudentCommand : IRequest<ApiResponse<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
