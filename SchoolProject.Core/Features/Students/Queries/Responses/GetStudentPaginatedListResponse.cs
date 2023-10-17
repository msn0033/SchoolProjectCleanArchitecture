namespace SchoolProject.Core.Features.Students.Queries.Responses
{
    public class GetStudentPaginatedListResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        public GetStudentPaginatedListResponse(int id, string name, string address, string phone, string departmentName)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            DepartmentName = departmentName;
        }
    }
}
