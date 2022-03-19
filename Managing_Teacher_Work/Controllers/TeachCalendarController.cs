using Managing_Teacher_Web.Common;
using Managing_Teacher_Web.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Service.Service.ClassService;
using Teacher_Manage_Service.Service.TeachCalendarService;
using Teacher_Manage_Service.Service.TeacherService;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class TeachCalendarController : BaseController
    {
        private readonly ITeachCalendarService _teachCalendarService;
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classService;

        public TeachCalendarController(ITeachCalendarService teachCalendarService, ITeacherService teacherService, IClassService classService)
        {
            _teachCalendarService = teachCalendarService;
            _teacherService = teacherService;
            _classService = classService;
        }
        //public async Task<ActionResult> Index()
        //{
        //    ViewBag.Teachers = (await _teacherService.GetTeachers()).OrderByDescending(x => x.Name_Teacher);
        //    ViewBag.Classes = (await _classService.GetClasses()).OrderByDescending(x => x.Name);
        //    return View();
        //}

        [HttpGet]
        public async Task<ActionResult> ManageTeachCalendar()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            ViewBag.Classes = await _classService.GetClasses();
            var teachers = await _teacherService.GetTeachers();
            ViewBag.Teachers = teachers;
            if (session.GroupID.Equals("ADMIN"))
            {
                ViewBag.TeachCalendars = _teachCalendarService.GetTeachCalendars(allowTracking: false);
                return View();
            }
            else
            {
                ViewBag.TeachCalendars = _teachCalendarService.GetTeachCalendars(teachers.FirstOrDefault(x => x.UserID == GetUserID()).ID,false);
                return View();
                ;
            }
        }

        public ActionResult GetTeachCalData(int id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var teachCalendar = _teachCalendarService.GetTeachCalendarById(id);
            return Json(JsonConvert.SerializeObject(teachCalendar, Formatting.Indented, jss), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(TeachCalendarVM teachCalendarVM, string submit)
        {
            if (submit.Equals("Thêm"))
            {
                var check = _teachCalendarService.AddTeachCalendar(teachCalendarVM);
                if (check)
                {
                    SetAlert("Thêm thông tin thành công! :D", "success");
                    return RedirectToAction("ManageTeachCalendar");
                }
                SetAlert("Thêm thông tin thất bại! D:", "error");
                return RedirectToAction("ManageTeachCalendar");
            }
            else if (submit.Equals("Cập Nhật"))
            {
                var check = _teachCalendarService.UpdateTeachCalendar(teachCalendarVM);
                if (check)
                {
                    SetAlert("Cập nhật thông tin thành công! :D", "success");
                    return RedirectToAction("ManageTeachCalendar");
                }
                SetAlert("Cập nhật thông tin thất bại! D:", "error");
                return RedirectToAction("ManageTeachCalendar");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Cancel(int id)
        {
            try
            {
                var check = _teachCalendarService.Cancel(id);
                if (check)
                {
                    SetAlert("Hoãn lớp thành công! :D", "success");
                    return RedirectToAction("ManageTeachCalendar");
                }
                SetAlert("Hoãn lớp thất bại! D:", "error");
                return RedirectToAction("ManageTeachCalendar");
            }
            catch (Exception)
            {
                SetAlert("Hoãn lớp thất bại! D:", "error");
                return RedirectToAction("ManageTeachCalendar");
            }
        }

        public ActionResult DeleteTeachCalendar(int id)
        {
            var check = _teachCalendarService.DeleteTeachCalendar(id);
            if (check)
            {
                SetAlert("Xoá thành công! :D", "success");
                return RedirectToAction(nameof(ManageTeachCalendar));
            }
            SetAlert("Xoá thất bại! D:", "error");
            return RedirectToAction("ManageTeachCalendar");
        }

        //public JsonResult GetTeachCalendars()
        //{
        //    var session = (UserLogin)Session[CommonConstants.USER_SESSION];
        //    if (session.GroupID.Equals("ADMIN"))
        //    {
        //        var teachCalendars = _teachCalendarService.GetTeachCalendars();
        //        return new JsonResult { Data = teachCalendars, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }
        //    else
        //    {
        //        var teachCalendars = _teachCalendarService.GetTeachCalendars(GetUserID());
        //        return new JsonResult { Data = teachCalendars, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }
        //}

        //[HttpPost]
        //public JsonResult SaveTeachCalendar(TeachCalendarVM teachCalendarVM)
        //{
        //    var status = false;
        //    var teachCalendar = _teachCalendarService.GetTeachCalendarById(teachCalendarVM.ID);
        //    if(teachCalendar != null)
        //    {
        //        var check = _teachCalendarService.UpdateTeachCalendar(teachCalendarVM);
        //        if(!check)
        //        {
        //            status = false;
        //        }    
        //        else
        //        {
        //            status = true;
        //        }    
        //    }    
        //    else
        //    {
        //        var check = _teachCalendarService.AddTeachCalendar(teachCalendarVM);
        //        if (check)
        //        {
        //            status = true;
        //        }
        //        else
        //        {
        //            status = false;
        //        }    
        //    }    
        //    return new JsonResult { Data = new { status = status } };
        //}


        //[HttpPost]
        //public JsonResult DeleteTeachCalendar(int id)
        //{
        //    var check = _teachCalendarService.DeleteTeachCalendar(id);
        //    return new JsonResult { Data = new { status = check } };
        //}

        private int GetUserID()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            return session.ID;
        }
    }
}
