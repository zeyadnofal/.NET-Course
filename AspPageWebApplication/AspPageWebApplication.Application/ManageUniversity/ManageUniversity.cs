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

        public void AddNewUniversity(UniversityDTO university)
        {
            context.Universities.Add(new University()
            {
                Name = university.Name,
                Address = university.Address
            });
            context.SaveChanges();
        }

        public void DeleteUniversity(int universityID)
        {
            var uni = context.Universities.Where(u => u.ID == universityID).FirstOrDefault();
            context.Remove(uni);
            context.SaveChanges();
        }

        public void EditUniversity(int universityID, UniversityDTO university)
        {
            var uni = context.Universities.FirstOrDefault(u => u.ID == universityID);
            uni.Name = university.Name;
            uni.Address = university.Address;
            context.SaveChanges();
        }

        public UniversityDTOList GetUniversities()
        {
            UniversityDTOList Universities = new UniversityDTOList()
            {
                Universities = context.Universities.ToList().Select(u => new UniversityDTO()
                {
                    ID = u.ID,
                    Name = u.Name,
                    Address = u.Address,
                    StudentCount = context.Students.Where(s => s.UniversityID == u.ID).ToList().Count
                }).ToList(), universitiesCount = context.Universities.Count()
            };
            return Universities;
        }

        public UniversityDTOList GetUniversitiesByName(string universityName)
        {
            var uniNames = context.Universities.Where(u => u.Name.Contains(universityName)).ToList();
            UniversityDTOList universities = new UniversityDTOList()
            {
                Universities = uniNames.Select(u => new UniversityDTO()
                {
                    ID = u.ID,
                    Name = u.Name,
                    Address = u.Address,
                    StudentCount = context.Students.Where(s => s.UniversityID == u.ID).ToList().Count
                }).ToList(),
                universitiesCount = uniNames.Count
            };
            return universities;
        }

        public UniversityDTO GetUniversityByID(int universityID)
        {
            var uni = context.Universities.Where(u => u.ID == universityID).FirstOrDefault();
            if (uni != null)
            {
                UniversityDTO university = new UniversityDTO()
                {
                    Name = uni.Name,
                    Address = uni.Address,
                    ID = uni.ID,
                    StudentCount = context.Students.Where(s => s.UniversityID == universityID).Count()
                };
                return university;
            }
            else return null;
        }
    }
}
