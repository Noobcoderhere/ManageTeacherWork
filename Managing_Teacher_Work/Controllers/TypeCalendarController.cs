using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Service.Service.WorkingCalendarService;
using Teacher_Manage_Core.ViewModel.WorkingCalendar;
using System.Threading.Tasks;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class TypeCalendarController : BaseController
    {
        private readonly IWorkingCalendarService _workingCalendarService;

        public TypeCalendarController(IWorkingCalendarService workingCalendarService)
        {
            _workingCalendarService = workingCalendarService;
        }

        public async Task<ActionResult> Index()
        {
            var listTypeCalendar = await _workingCalendarService.GetCalendarTypes();
            ViewBag.listTypeCalendar = listTypeCalendar;
            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = _workingCalendarService.GetCalendarTypeById(id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Add(CalendarTypeVM model, string submit)
        {
            if (submit == "Thêm")
            {
                var check = _workingCalendarService.AddCalendarType(model);
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
                var check = _workingCalendarService.UpdateCalendarType(model);
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
                var list = await _workingCalendarService.GetCalendarTypes();
                return View("Index", list.OrderBy(s => s.TypeName).ToList());
            }
        }

        public ActionResult Delete(int id)
        {
            var check = _workingCalendarService.DeleteCalendarType(id);
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