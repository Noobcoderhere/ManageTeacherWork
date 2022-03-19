using Managing_Teacher_Web.Controllers;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Teacher_Manage_Service.Service.ClassService;
using Teacher_Manage_Service.Service.MajorService;
using Teacher_Manage_Service.Service.StudentService;
using Teacher_Manage_Service.Service.TeacherService;
using Teacher_Manage_Service.Service.UserService;

namespace Managing_Teacher_Work.Controllers
{
    public class FrontendController : BaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly IMajorService _majorService;
        private readonly IClassService _classService;
        private readonly IUserService _userService;

        public FrontendController(ITeacherService teacherService, IStudentService studentService, IMajorService majorService, IClassService classService, IUserService userService)
        {
            _teacherService = teacherService;
            _studentService = studentService;
            _majorService = majorService;
            _classService = classService;
            _userService = userService;
        }
      
        public ActionResult ProfileTeacher(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            ViewBag.Teacher = teacher;
            var major = _majorService.GetMajorById(teacher.MajorID);
            ViewBag.Major = major;
            return View();
        }
        public ActionResult ProfileStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            ViewBag.Student = student;
            var classs = _classService.GetClassById(student.ClassID);
            ViewBag.Class = classs;

            return View();

        }

        public async Task<ActionResult> ProfileUser(int id)
        {
            var user = _userService.GetUserByID(id);
            
            var teachers = await _teacherService.GetTeachersByCondition(x => x.UserID == id);
            var teacher = teachers.FirstOrDefault();
            if(teacher != null)
            {
                user.TeacherID = teacher.ID;
            }
            else
            {
                user.TeacherID = null;
            }    
            ViewBag.User = user;
            return View();
        }
    }
}