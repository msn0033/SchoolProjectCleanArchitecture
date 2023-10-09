using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {
        public int StudId { get; set; }
        public int SubId { get; set; }

        public virtual Student Student { get; set; } = new();
        public virtual Subject Subject { get; set; } = new();

    }
  }
