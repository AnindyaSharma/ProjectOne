﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department should have a name")]
        public string Name { get; set; }
    }
}
