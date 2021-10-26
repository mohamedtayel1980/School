using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Evaluation:Entity
    {
        [Required]
        public int Grade { get; set; }
        public string AdditionalExplanation { get; set; }
        //[ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
