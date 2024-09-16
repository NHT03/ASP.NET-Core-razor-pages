using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Core.Models;

namespace WebMVC.Core.Context
{
    public interface IMySchoolContext
    {
         DbSet<Student> Students { get; set; }
         DbSet<Class> Classes { get; set; }

        int SaveChanges();
        
        Task<int> SaveChangesAsync(CancellationToken cacnellationToken = default);
    }
}
