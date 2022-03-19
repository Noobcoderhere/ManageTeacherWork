using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Core.ViewModel.Person;
using Teacher_Manage_Service.Service.TeacherService;
using System.Threading.Tasks;
using Teacher_Manage_Service.Service.MajorService;
using Teacher_Manage_Service.Service.UserService;
using System.Collections.Generic;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly IMajorService _majorService;
        private readonly IUserService _userService;

        public TeacherController(ITeacherService teacherService, IMajorService majorService, IUserService userService) 
        {
            _teacherService = teacherService;
            _majorService = majorService;
            _userService = userService;
        }
        
        public async Task<ActionResult> GetTeacherByMajor(int majorID)
        {
            var major = _majorService.GetMajorById(majorID);
            ViewBag.Major = major;
            var listTeacher = await _teacherService.GetTeachersByCondition(x => x.MajorID == majorID);
            ViewBag.ListTeacher = listTeacher;
            return View();
        }

        public async Task<ActionResult> Index()
        {
            var listTeacher = await _teacherService.GetTeachers();
            ViewBag.ListTeacher = listTeacher;
            var listMajor = await _majorService.GetMajors();
            ViewBag.ListMajor = listMajor.OrderByDescending(x => x.CreatedDate);
            var listUser = await _userService.GetUsers();
            ViewBag.ListUser = listUser;
            return View();
        }
        
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = _teacherService.GetTeacherById(id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Add(TeacherVM model)
        {
          
                var check = _teacherService.AddTeacher(model);
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

        public ActionResult Update(TeacherVM model)
        {
            var check = _teacherService.UpdateTeacher(model);
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

        public ActionResult Delete(int id)
        {
            var check = _teacherService.DeleteTeacher(id);
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