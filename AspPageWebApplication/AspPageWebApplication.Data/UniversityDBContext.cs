using AspPageWebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Data
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
