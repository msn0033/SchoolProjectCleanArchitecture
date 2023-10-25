using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }

        public int Id { get; set; }

        public string? NameAr { get; set; }
        public string? NameEn { get; set; }

        // 1 to 1 Department & Instructor

        public int? InstructorManagerId { get; set; }
        public Instructor? InstructorManager { get; set; }

        // m to 1 Department & Instructor
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

       // m to 1 Department & Students
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        //m to m
        public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();

        // from m to m ==> m to 1
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmetSubject>();


      

       

    }
}
