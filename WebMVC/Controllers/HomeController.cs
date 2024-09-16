using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Core.Models;
using WebMVC.Core.Repository;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository classRepository;
        public HomeController(ILogger<HomeController> logger, IStudentRepository rep, IClassRepository _classRep)
        {
            _logger = logger;
            _studentRepository = rep;
            classRepository = _classRep;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Students(string sort, bool desc)
        {
            List<Student> students = _studentRepository.GetAll();
            if (sort != null)
                students = _studentRepository.SortBy(sort, desc);

            return View(students);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            Console.WriteLine(student.ToString());
            if (student == null)
            {
                ViewBag.Result = 0;
                return View();
            }
            int result = _studentRepository.Add(student);

            ViewBag.Result = result;


            return View();
        }
        public IActionResult DeleteStudent(int id)
        {
            ViewBag.Result = _studentRepository.DeleteStudent(id);
            return RedirectToAction("Students");
        }
        public IActionResult StudentDetails(int id)
        {
            Student s = _studentRepository.Find(id);
            return View(s);
        }
        public IActionResult EditStudent(int id)
        {
            Student s = _studentRepository.Find(id);
            return View(s);
        }
        [HttpPost] 
        public IActionResult EditStudent(Student s)
        {
            _studentRepository.UpdateStudent(s);
            return View(s);
        }

        public IActionResult Classes() { 
            List<Class> classes = new List<Class>();
            classes = classRepository.getAll();
            return View(classes); 
        }
        public IActionResult AddClass()
        {
            List<Student> students = new List<Student>();
            students = _studentRepository.GetAll();
            ViewBag.Students = students;
            return View();
        }
        [HttpPost]
        public IActionResult AddClass(Class c, List<string> studentIds)
        {
            classRepository.Add(c, studentIds);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
