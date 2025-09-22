using C44_G04_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.DAL.Data.Contexts
{
    public class CompanyDBContext : DbContext
    {
            public CompanyDBContext() : base()
            {

                
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CompanyDB;Trusted_Connection = True; TrustServerCertificate = True");
        }

        public DbSet<Department> Departments { get; set; }
    }
}
