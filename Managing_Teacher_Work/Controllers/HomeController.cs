using Managing_Teacher_Web.Common;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Teacher_Manage_Service.Service.ClassService;
using Teacher_Manage_Service.Service.EventService;
using Teacher_Manage_Service.Service.MajorService;
using Teacher_Manage_Service.Service.StudentService;
using Teacher_Manage_Service.Service.TeacherService;
using Teacher_Manage_Service.Service.UserService;
using Teacher_Manage_Service.Service.WorkingCalendarService;
using Teacher_Manage_Service.Service.WorkService;

namespace Managing_Teacher_Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IWorkingCalendarService _workingCalendarService;
        private readonly IMajorService _majorService;
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        private readonly IWorkService _workService;
        private readonly IUserService _userService;

        public HomeController(IWorkingCalendarService workingCalendarService, IEventService eventService, IMajorService majorService, IStudentService studentService, IClassService classService, ITeacherService teacherService, IWorkService workService, IUserService userService)
        {
            _workingCalendarService = workingCalendarService;
            _majorService = majorService;
            _studentService = studentService;
            _classService = classService;
            _teacherService = teacherService;
            _workService = workService;
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            var listCW = await _workingCalendarService.GetWorkingCalendars();
            ViewBag.listCW = listCW;
            return View();
        }

        public async Task<ActionResult> ListStudent(long idClass)
        {
            var ClassDetails = _classService.GetClassById((int)idClass);
            ViewBag.ClassDetails = ClassDetails;
            var ListStudentOfClass = await _studentService.GetStudentsByCondition(x => x.ClassID == idClass);
            ViewBag.ListStudent = ListStudentOfClass;
            return View();
        }

        public ActionResult CalendarWorkingDetails(int id)
        {
            var cw = _workingCalendarService.GetWorkingCalendarById(id);
            ViewBag.Cw = cw;
            ViewBag.teacher = _teacherService.GetTeacherById(cw.TeacherID);
            ViewBag.work = _workService.GetWorkByID(cw.WorkID);
            ViewBag.typecalendar = _workingCalendarService.GetCalendarTypeById(cw.TypeCalendarID);
            return View();
        }
     
        public ActionResult CalendarWorkingDetails_Level2(int id)
        {
            var cw = _workingCalendarService.GetWorkingCalendarById(id);
            ViewBag.Calendarworking = cw;
            ViewBag.teacher = _teacherService.GetTeacherById(cw.TeacherID);
            ViewBag.work = _workService.GetWorkByID(cw.WorkID);
            ViewBag.typecalendar = _workingCalendarService.GetCalendarTypeById(cw.TypeCalendarID);
            return View();
        }

        public ActionResult Cancel(int id)
        {
            try
            {
                var check = _workingCalendarService.Cancel(id);
                if (check)
                {
                    SetAlert("Hoãn lịch thành công! :D", "success");
                    return RedirectToAction("Index");
                }
                SetAlert("Hoãn lịch thất bại! D:", "error");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                SetAlert("Hoãn lịch thất bại! D:", "error");
                return RedirectToAction("Index");
            }
        }

        public ActionResult Completed(int id)
        {
            try
            {
                var check = _workingCalendarService.Completed(id);
                if (check)
                {
                    SetAlert("Đã hoàn thành công việc! :D", "success");
                    return RedirectToAction("Index");
                }
                SetAlert("Chưa hoàn thành công việc! D:", "error");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                SetAlert("Hiện chưa thể hoàn thành công việc! D:", "error");
                return RedirectToAction("Index");
            }
        }

        public ActionResult Continue(int id)
        {
            try
            {
                var check = _workingCalendarService.Continue(id);
                if (check)
                {
                    SetAlert("Đã tiếp tục công việc! :D", "success");
                    return RedirectToAction("Index");
                }
                SetAlert("Chưa tiếp tục công việc! D:", "error");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                SetAlert("Hiện chưa thể tiếp tục công việc! D:", "error");
                return RedirectToAction("Index");
            }
        }

        private int GetUserID()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            return session.ID;
        }
    }
}