using MediatR;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.ModelsHelper.Enums;
using SchoolProject.Helper.Wrappers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQueryRequest : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderByEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
