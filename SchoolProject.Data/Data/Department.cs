using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Data
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
       
        public int Id { get; set; }
       
        public string Name { get; set; }=string.Empty;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }  

        public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
  }
