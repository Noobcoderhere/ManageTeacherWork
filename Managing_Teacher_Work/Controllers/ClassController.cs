using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Service.Service.ClassService;
using Teacher_Manage_Service.Service.TeacherService;
using Teacher_Manage_Service.Service.MajorService;
using Teacher_Manage_Core.ViewModel;
using System.Threading.Tasks;

namespace Managing_Teacher_Work.Controllers
{
    public class ClassController : BaseController
    {
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        private readonly IMajorService _majorService;

        public ClassController(IClassService classService, ITeacherService teacherService, IMajorService majorService)
        {
            _classService = classService;
            _teacherService = teacherService;
            _majorService = majorService;
        }

        public async Task<ActionResult> GetClassList()
        {
            var classes = await _classService.GetClasses();
            ViewBag.Classes = classes.OrderByDescending(x => x.CreatedDate);
            return View();
        }

        public async Task<ActionResult> GetClassesByMajor(int majorId)
        {
            var major = _majorService.GetMajorById(majorId);
            ViewBag.Major = major;
            var classes = await _classService.GetClassesByCondition(x => x.MajorID == majorId);
            ViewBag.ListClass = classes.OrderByDescending(x => x.CreatedDate);
            return View();
        }

        public async Task<ActionResult> Index(string id)
        {
            var listTeacher = await _teacherService.GetTeachers();
            ViewBag.listTeacher = listTeacher;
            var listScience = await _majorService.GetMajors();
            ViewBag.listScience = listScience;
            var listClass = await _classService.GetClasses();
            ViewBag.listClass = listClass;
            return View();
        }
        public ActionResult GetData(int id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var cl = _classService.GetClassById(id);
            var result = JsonConvert.SerializeObject(cl, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Add(ClassVM model, string submit)
        {
            if (submit == "Thêm")
            {
                var check = _classService.AddClass(model);
                if (check)
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
                var check = _classService.UpdateClass(model);
                if (check)
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
                var list = await _classService.GetClasses();
                return View("Index", list.OrderBy(s => s.Name).ToList());
            }
        }

        public ActionResult Delete(int id)
        {
            var check = _classService.DeleteClass(id);
            if (check)
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