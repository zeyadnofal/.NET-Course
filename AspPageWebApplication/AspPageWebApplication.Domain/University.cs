using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspPageWebApplication.Domain
{
    public class University
    {
        public University()
        {
            Students = new List<Student>();
        }
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public List<Student> Students { get; set; }
    }
}
