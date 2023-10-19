using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {

        public int Id { get; set; }

        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;

        public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
