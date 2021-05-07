using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspPageWebApplication.Domain;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public class ManageUniversity : IManageUniversity
    {
        public List<University> GetUniversities()
        {
            return new List<University>()
            {
                new University() {ID = 1, Name = "Ahram Canadian University", Address = "6 October"},
                new University() {ID = 2, Name = "Cairo University", Address = "Giza"},
                new University() {ID = 3, Name = "Ain Shams University", Address = "Cairo" },
                new University() {ID = 4, Name = "Helwan University", Address = "Helwan" },
                new University() {ID = 5, Name = "Aswan University", Address = "Aswan"}
            };
        }

        public University GetUniversityByID(int universityID)
        {
            return GetUniversities().SingleOrDefault(un => un.ID == universityID);
        }
    }
}
