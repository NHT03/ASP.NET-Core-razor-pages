using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Core.Models;

namespace WebMVC.Core.Repository
{
    public interface IStudentRepository
    {
        Student Find(int id);
        int  Add(Student student);
        Task<int> AddAsync(Student student);
        int UpdateStudent(Student student);
        Task UpdateAsync(Student student);
        int DeleteStudent(int id);
        int DeleteStudent(Student student);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(Student student);
        List<Student> GetAll();
        List<Student> GetAllAsync();
        List<Student> SortBy(string sort, bool desc);
    }
}
