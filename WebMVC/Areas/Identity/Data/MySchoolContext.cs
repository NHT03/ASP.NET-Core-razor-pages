using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebMVC.Core.Models;

namespace WebMVC.Core.Context;

public class MySchoolContext1 : IdentityDbContext<IdentityUser>, IMySchoolContext
{
    public DbSet<Student> Students { get ; set ; }
    public DbSet<Class> Classes { get; set; }
  
        public MySchoolContext1(DbContextOptions<MySchoolContext1> options) : base(options)
        {

        }


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
