using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class StudentDtoForUpdate
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name can't be longer than 200 characters")]
        public string Name { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Please enter valid Age ")]
        public int? Age { get; set; }

    }
}
