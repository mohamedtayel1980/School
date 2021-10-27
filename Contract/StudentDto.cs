using System;
using System.Collections.Generic;

namespace Contracts
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public bool IsRegularStudent { get; set; }
        public StudentDetailsDto StudentDetails { get; set; }
        public List<EvaluationDto> EvaluationsDto { get; set; }
    }
}
