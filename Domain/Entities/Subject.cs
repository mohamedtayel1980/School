using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject:Entity
    {
        public string SubjectName { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
