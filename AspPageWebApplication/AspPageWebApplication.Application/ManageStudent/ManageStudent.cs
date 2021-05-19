using AspPageWebApplication.Data;
using AspPageWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AspPageWebApplication.Application.ManageStudent
{
    public class ManageStudent : IManageStudent
    {
        private readonly UniversityDBContext context;

        public ManageStudent(UniversityDBContext context)
        {
            this.context = context;
        }

        public void AddStudent(StudentDTO student, int universityID)
        {
            context.Universities.Where(uni => uni.ID == universityID).FirstOrDefault().Students.Add(new Student()
            {
                Name = student.Name,
                Grade = student.Grade,
                UniversityID = student.UniversityID
            });
            context.SaveChanges();
        }

        public void DeleteStudent(int studentID)
        {
            var student = context.Students.Where(s => s.ID == studentID).FirstOrDefault();
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void EditStudent(StudentDTO student)
        {
            var editStudent = context.Students.Where(s => s.ID == student.ID).FirstOrDefault();
            editStudent.Name = student.Name;
            editStudent.Grade = student.Grade;
            context.SaveChanges();
        }

        public StudentDTO GetStudentByID(int studentID)
        {
            var getStudent = context.Students.Where(s => s.ID == studentID).FirstOrDefault();
            if (getStudent != null)
            {
                StudentDTO Student = new StudentDTO()
                {
                    Name = getStudent.Name,
                    Grade = getStudent.Grade,
                    ID = getStudent.ID,
                    UniversityID = getStudent.UniversityID
                };
                return Student;
            }
            else return null;
        }

        public StudentDTOList GetStudentByName(string name)
        {
            var studentsName = context.Students.Where(s => s.Name.Contains(name)).ToList();
            StudentDTOList Students = new StudentDTOList()
            {
                Students = studentsName.Select(s => new StudentDTO()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Grade = s.Grade,
                    UniversityID = s.UniversityID
                }).ToList()
            };
            return Students;
        }

        public StudentDTOList GetStudentsByUniversityID(int universityID)
        {
            var studentsID = context.Universities.Where(uni => uni.ID == universityID).Include(uni => uni.Students).FirstOrDefault().Students.ToList();
            StudentDTOList Students = new StudentDTOList()
            {
                Students = studentsID.Select(s => new StudentDTO()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Grade = s.Grade,
                    UniversityID = s.UniversityID
                }).ToList()
            };
            return Students;
        }
    }
}
