using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Domain
{
    public class University
    {
        public University()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
