using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Core.Context;
using WebMVC.Core.Models;

namespace WebMVC.Core.Repository
{
    public class ClassRepository : IClassRepository
    {
        IMySchoolContext db;
        public ClassRepository(IMySchoolContext _db)
        {
            this.db = _db;
        }

        public int Add(Class cls, List<string> studentIds)
        {
            try
            {

                List<Student> students = new List<Student>();
                foreach (string studentId in studentIds)
                {
                    Student s = db.Students.FirstOrDefault(x => x.Id == Int32.Parse(studentId));
                    students.Add(s);
                }
                cls.Students = students;
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return 0;
            }

            return 0;
        }

        public int Delete(int id)
        {
            try
            {
                Class c = db.Classes.FirstOrDefault(p => p.Id == id);
                db.Classes.Remove(c);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;
        }

        public List<Class> getAll()
        {
            return db.Classes.ToList();
        }

        public int Update(Class cls, List<string> studentIds)
        {
            try
            {
                Class c = db.Classes.FirstOrDefault(p=>p.Id== cls.Id);
                List<Student> students = new List<Student>();
                foreach (string studentId in studentIds)
                {
                    Student s = db.Students.FirstOrDefault(x => x.Id == Int32.Parse(studentId));
                    students.Add(s);
                }
                cls.Students = students;
                c.Name = cls.Name;
                c.Students = students;
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

            return 0;
        }
    }
}
