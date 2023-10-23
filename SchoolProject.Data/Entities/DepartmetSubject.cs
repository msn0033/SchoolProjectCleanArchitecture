namespace SchoolProject.Data.Entities
{
    public class DepartmetSubject
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
        public virtual Department Department { get; set; } = new();
        public virtual Subject Subjects { get; set; } = new();
    }
}
