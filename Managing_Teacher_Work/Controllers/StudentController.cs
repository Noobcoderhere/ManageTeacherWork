using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Service.Service.StudentService;
using Teacher_Manage_Service.Service.ClassService;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.Person;
using Teacher_Manage_Service.Service.TeacherService;

namespace Managing_Teacher_Work.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;

        public StudentController(IStudentService studentService, IClassService classService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _classService = classService;
            _teacherService = teacherService;
        }

        public async Task<ActionResult> GetListStudentInClass(int idClass)
        {
            var classDetail = _classService.GetClassById(idClass);
            ViewBag.Teacher = _teacherService.GetTeacherById(classDetail.TeacherID);
            ViewBag.ClassDetail = classDetail;
            var listStudentsOfClass = await _studentService.GetStudentsByCondition(x => x.ClassID == idClass);
            ViewBag.ListStudent = listStudentsOfClass;
            return View();
        }

        public async Task<ActionResult> Index()
        {
            var listStudent = await _studentService.GetStudents();
            ViewBag.listStudent = listStudent;
            var listClass = await _classService.GetClasses();
            ViewBag.listClass = listClass;
            return View();
        }

        public ActionResult getList(int id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = _studentService.GetStudentById(id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Add(StudentVM model, string submit)
        {
            if (submit == "Thêm")
            {
                var check = _studentService.AddStudent(model);
                model = null;
                if(check)
                {
                    SetAlert("Thêm thông tin thành công! :D", "success");
                    return RedirectToAction("Index");
                }    
                else
                {
                    SetAlert("Thêm thông tin thất bại! D:", "error");
                    return RedirectToAction("Index");
                }    
            }
            else if (submit == "Cập Nhật")
            {
                var check = _studentService.UpdateStudent(model);
                model = null;
                if(check)
                {
                    SetAlert("Cập nhật thông tin thành công! :D", "success");
                    return RedirectToAction("Index");
                }    
                else
                {
                    SetAlert("Cập nhật thông tin thất bại! D:", "error");
                    return RedirectToAction("Index");
                }    
            }
            else
            {
                var list = await _studentService.GetStudents();
                return View("Index", list.OrderBy(x => x.Name_Student));
            }
        }

        public ActionResult Delete(int id)
        {
            var check = _studentService.DeleteStudent(id);
            if(check)
            {
                SetAlert("Xoá thành công! :D", "success");
                return RedirectToAction("Index");
            }    
            else
            {
                SetAlert("Xoá thất bại! D:", "error");
                return RedirectToAction("Index");
            }      
        }

    }
}