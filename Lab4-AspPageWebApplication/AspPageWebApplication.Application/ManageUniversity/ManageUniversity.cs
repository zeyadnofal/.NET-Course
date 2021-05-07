using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspPageWebApplication.Domain;
using AspPageWebApplication.Data;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public class ManageUniversity : IManageUniversity
    {
        private readonly UniversityDBContext context;

        public ManageUniversity(UniversityDBContext context)
        {
            this.context = context;
        }

        public void AddNewUniversity(University university)
        {
            context.Universities.Add(university);
            context.SaveChanges();
        }

        public void DeleteUniversity(int universityID)
        {
            var uni = context.Universities.SingleOrDefault(un => un.ID == universityID);
            context.Remove(uni);
        }

        public void EditUniversity(University university)
        {
            var uni = context.Universities.SingleOrDefault(un => un.ID == university.ID);
            if(uni != null)
            {
                uni.Name = university.Name;
                uni.Address = university.Address;
                context.SaveChanges();
            }
        }
        public List<University> GetUniversities()
        {
            return context.Universities.ToList();
        }

        public List<University> GetUniversitiesByName(string universityName)
        {
            return context.Universities.Where(un => un.Name.Contains(universityName)).ToList();
        }

        public University GetUniversityByID(int universityID)
        {
            return context.Universities.SingleOrDefault(un => un.ID == universityID);
        }
    }
}
