using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspPageWebApplication.Domain
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Grade { get; set; }
        public int UniversityID { get; set; }
    }
}
