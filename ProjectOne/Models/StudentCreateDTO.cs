using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class StudentCreateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student should have a name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int DepartmentId { get; set; }
    }
}
