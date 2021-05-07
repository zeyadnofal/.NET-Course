using System;
using System.Collections.Generic;
using System.Text;
using AspPageWebApplication.Domain;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public interface IManageUniversity
    {
        List<University> GetUniversities();
        University GetUniversityByID(int universityID);
        List<University> GetUniversitiesByName(string universityName);
        void DeleteUniversity(int universityID);
        void AddNewUniversity(University university);
        void EditUniversity(University university);
    }
}
