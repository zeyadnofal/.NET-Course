using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityApp.Domain;

namespace UniversityApp.Data
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }

        private static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) =>
            category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=University;Integrated Security=True");
            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging();
        }
    }
}
