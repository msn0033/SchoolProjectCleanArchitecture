using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Student
    {
       
        public int Id { get; set; }
       
        public string Name { get; set; } = string.Empty;
      
        public string Address { get; set; }=string.Empty;

        public string Phone { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;

        public virtual ICollection<Subject> Subjects { get; set; }  = new HashSet<Subject>();
    }
  }
