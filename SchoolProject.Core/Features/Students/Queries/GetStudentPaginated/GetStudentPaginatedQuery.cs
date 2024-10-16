using MediatR;
using SchoolProject.Data.ModelsHelper.Enums;
using SchoolProject.Core.Base.PaginatedList;

namespace SchoolProject.Core.Features.Students.Queries.GetStudentPaginated
{
    public class GetStudentPaginatedQuery : IRequest<PaginatedList<StudentResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderByEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
