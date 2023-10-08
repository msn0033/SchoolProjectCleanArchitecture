using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Data
{
    public class DepartmetSubject
    {
        [Key]
        
        public int DepId { get; set; }
        public int SubId { get; set; }
        public virtual Department Department { get; set; } = new();
        public virtual Subject Subjects { get; set; } =new();
    }
  }
