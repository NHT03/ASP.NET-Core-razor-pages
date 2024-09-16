using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Core.Context;
using WebMVC.Core.Models;

namespace WebMVC.Core.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMySchoolContext _db;
        public StudentRepository(IMySchoolContext db)
        {
            _db = db;
        }

        public int Add(Student student)
        {
            try
            {
                _db.Students.Add(new Student
                {
                    Name = student.Name,
                    Address = student.Address,
                    Dob = student.Dob,
                    Phone = student.Phone,
                    Classes = new List<Class>()
                });
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"Exc");
                return 0;
            }

        }

        public Task<int> AddAsync(Student student)
        {
            try
            {
                _db.Students.AddAsync(new Student
                {
                    Name = student.Name,
                    Address = student.Address,
                    Dob = student.Dob,
                    Phone = student.Phone,
                    Classes = new List<Class>()
                });
                return _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult(0);
            }
            
        }

        public Task<int> DeleteAsync(int id)
        {
            Student student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return Task.FromResult(0);
            }
            else
            {
                _db.Students.Remove(student);
            }
            return _db.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(Student student)
        {
            Student studentx = _db.Students.FirstOrDefault(x => x.Id == student.Id);
            if (studentx == null)
            {
                return Task.FromResult(0);
            }
            else
            {
                _db.Students.Remove(studentx);
            }
            return _db.SaveChangesAsync();
        }

        public int DeleteStudent(int id)
        {
            Student student = _db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return 0;
            }
            else
            {
                _db.Students.Remove(student);
            }
            return _db.SaveChanges();
        }

        public int DeleteStudent(Student student)
        {
            Student studentx = _db.Students.FirstOrDefault(x => x.Id == student.Id);
            if (studentx == null)
            {
                return 0;
            }
            else
            {
                _db.Students.Remove(studentx);
            }
            return _db.SaveChanges();
        }

        public Student Find(int id)
        {
            return _db.Students.FirstOrDefault(x=>x.Id == id);
        }

        public List<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public List<Student> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<Student> SortBy(string sort, bool desc)
        {
            
            if (sort == "id")
            {
                if (desc) return _db.Students.OrderByDescending(x => x.Id).ToList();
                return _db.Students.OrderBy(x => x.Id).ToList();
            }
            if (sort == "dob")
            {
                if (desc) return _db.Students.OrderByDescending(x => x.Dob).ToList();
                return _db.Students.OrderBy(x => x.Dob).ToList();
            }
            if (sort == "name")
            {
                if (desc) return _db.Students.OrderByDescending(x => x.Name).ToList();
                return _db.Students.OrderBy(x => x.Name).ToList();
            }
            if (sort == "address")
            {
                if (desc) return _db.Students.OrderByDescending(x => x.Address).ToList();
                return _db.Students.OrderBy(x => x.Address).ToList();
            }
            if (sort == "class")
            {
                if (desc) return _db.Students.OrderByDescending(x => x.Classes.FirstOrDefault().Name).ToList();
                return _db.Students.OrderBy(x => x.Classes.FirstOrDefault().Name).ToList();
            }
            if (sort == "phone")
            {
                if (desc) return _db.Students.OrderByDescending(x => x.Phone).ToList();
                return _db.Students.OrderBy(x => x.Phone).ToList();
            }
            return _db.Students.OrderBy(o => o.Id).ToList();
        }

        public Task UpdateAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public int UpdateStudent(Student student)
        {
            try
            {
                Student s = _db.Students.FirstOrDefault(x => x.Id == student.Id);
                if (s != null)
                {
                    s.Name = student.Name;
                    s.Address = student.Address;
                    s.Phone = student.Phone;
                    s.Dob = student.Dob;
                    return _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
                return 0;
        }
    }
}
