namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Address { get; set; }
        public string? Postion { get; set; }
        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }


        //m to 1
        public int? InstructoId { get; set; }
        public Instructor? Instructo { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        // m to m
        public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();

        // from m to m ==> m to 1
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();




    }
}
