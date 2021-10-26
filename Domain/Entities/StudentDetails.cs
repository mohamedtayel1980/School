using System;

namespace Domain.Entities
{
    public class StudentDetails:Entity
    {
        public string Address { get; set; }
        public string AdditionalInformation { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
