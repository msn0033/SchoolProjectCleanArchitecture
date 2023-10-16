namespace SchoolProject.Core.Features.Students.Queries.Responses
{
    public class StudentsListQueryResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;
    }
}
