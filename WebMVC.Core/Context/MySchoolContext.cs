using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Core.Models;

namespace WebMVC.Core.Context
{
    public class MySchoolContext: IdentityDbContext<IdentityUser>, IMySchoolContext
    {
        

        public MySchoolContext(DbContextOptions<MySchoolContext> options) : base(options)
        {
        
        }

        public DbSet<Student> Students { get ; set; }
        public DbSet<Class> Classes { get ; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Classes)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("ClassStudents"));

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    var tableName = entityType.GetTableName();
            //    if (tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6));
            //    }
            //}
        }
    }
}
