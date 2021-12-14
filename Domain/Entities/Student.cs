using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Student")]
    public class Student: ShapedEntity
    {
       
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Name { get; set; }
        public int? Age { get; set; }
        [NotMapped]
        public int LocalCalculation { get; set; }

        public bool IsRegularStudent { get; set; }
        public StudentDetails StudentDetails { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
