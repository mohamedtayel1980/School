using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class StudentDetails:BaseEntity
    {
        public string Address { get; set; }
        public string AdditionalInformation { get; set; }
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
