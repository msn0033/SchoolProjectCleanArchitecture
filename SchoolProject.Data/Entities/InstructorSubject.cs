namespace SchoolProject.Data.Entities
{
    public class InstructorSubject
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
        public virtual Instructor Instructor { get; set; } = new();
        public virtual Subject Subject { get; set; } = new();
    }
}
