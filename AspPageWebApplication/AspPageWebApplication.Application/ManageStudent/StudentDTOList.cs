using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Application.ManageStudent
{
    public class StudentDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int UniversityID { get; set; }
    }

    public class StudentDTOList
    {
        public List<StudentDTO> Students { get; set; }
    }
}
