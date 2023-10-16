using MediatR;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Helper.ResponseHelper;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class StudentByIdQuery : IRequest<Response<StudentsListQueryResponse>>
    {
        public int id { get; set; }
    }
}
