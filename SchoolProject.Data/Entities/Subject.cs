using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entities
{
    public class Subject : GeneralLocalizableEntity
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            Departments = new HashSet<Department>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int Period { get; set; }

        // from m to m ==> m to 1
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; } = new HashSet<DepartmetSubject>();
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();

        // m to m
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}





