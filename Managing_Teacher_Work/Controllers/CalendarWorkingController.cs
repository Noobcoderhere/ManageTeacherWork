using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Service.Service.WorkingCalendarService;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.WorkingCalendar;
using Teacher_Manage_Service.Service.TeacherService;
using Teacher_Manage_Service.Service.WorkService;
using System;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]

    public class CalendarWorkingController : BaseController
    {
        private readonly IWorkingCalendarService _workingCalendarService;
        private readonly ITeacherService _teacherService;
        private readonly IWorkService _workService;

        public CalendarWorkingController(IWorkingCalendarService workingCalendarService, ITeacherService teacherService, IWorkService workService)
        {
            _workingCalendarService = workingCalendarService;
            _teacherService = teacherService;
            _workService = workService;
        }

        public async Task<ActionResult> Index()
        {
            var listCW = await _workingCalendarService.GetWorkingCalendars();
            ViewBag.listCW = listCW;
            var listWork = await _workService.GetWorks();
            ViewBag.listWork = listWork;
            var listTeacher = await _teacherService.GetTeachers();
            ViewBag.listTeacher = listTeacher;

            var listTypeCalendar = await _workingCalendarService.GetCalendarTypes();
            ViewBag.listTypeCalendar = listTypeCalendar;
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

        public ActionResult GetWorkingCalendarData(int id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var wc = _workingCalendarService.GetWorkingCalendarByCondition(x => x.ID == id, true);
            var result = JsonConvert.SerializeObject(wc, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
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

        public ActionResult Add(WorkingCalendarVM model)
        {
            var check = _workingCalendarService.AddWorkingCalendar(model);
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

        public ActionResult Update(WorkingCalendarVM model)
        {
            var check = _workingCalendarService.UpdateWorkingCalendar(model);
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

        public async Task<IEnumerable<WorkingCalendarVM>> GetWorkingCalendars()
        {
            return await _workingCalendarService.GetWorkingCalendars();
        }
        public ActionResult Delete(int id)
        {
            var check = _workingCalendarService.DeleteWorkingCalendar(id);
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
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }

}