using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Application.ManageStudent
{
    public interface IManageStudent
    {
        StudentDTOList GetStudentsByUniversityID(int universityID);
        StudentDTOList GetStudentByName(string name);
        void AddStudent(StudentDTO student, int universityID);
        void DeleteStudent(int studentID);
        void EditStudent(StudentDTO student);
        StudentDTO GetStudentByID(int studentID);
    }
}
