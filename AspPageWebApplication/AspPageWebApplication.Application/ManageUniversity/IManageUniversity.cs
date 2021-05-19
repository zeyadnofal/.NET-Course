using System;
using System.Collections.Generic;
using System.Text;
using AspPageWebApplication.Domain;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public interface IManageUniversity
    {
        UniversityDTOList GetUniversities();
        UniversityDTO GetUniversityByID(int universityID);
        UniversityDTOList GetUniversitiesByName(string universityName);
        void DeleteUniversity(int universityID);
        void AddNewUniversity(UniversityDTO university);
        void EditUniversity(int universityID, UniversityDTO university);
    }
}
