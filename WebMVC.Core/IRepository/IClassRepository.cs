using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Core.Models;

namespace WebMVC.Core.Repository
{
    public interface IClassRepository
    {
        public List<Class> getAll();
        public int Add(Class cls, List<string> studentIds);
        public int Update(Class cls, List<string> studentIds);
        public int Delete(int id);

    }
}
