using System;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string  CreatedBY { get; set; }
        public DateTime  CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
