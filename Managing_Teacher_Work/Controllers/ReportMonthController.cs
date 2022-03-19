using Managing_Teacher_Web.Controllers;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Service.Service.ClassService;
using Teacher_Manage_Service.Service.FileService;
using Teacher_Manage_Service.Service.ReportService;
using Teacher_Manage_Service.Service.TeacherService;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class ReportMonthController : BaseController
    {
        // GET: ReportMonth
        private readonly IReportService _reportService;
        private readonly IFileService _fileService;
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;

        public ReportMonthController(IReportService reportService, IFileService fileService, IClassService classService, ITeacherService teacherService)
        {
            _reportService = reportService;
            _fileService = fileService;
            _classService = classService;
            _teacherService = teacherService;
        }

        public async Task<ActionResult> Statistics_Report()
        {
            var mon1 = await _reportService.GetReportsByMonth(1);
            ViewBag.mon1 = mon1;
            //---------------------

            var mon2 = await _reportService.GetReportsByMonth(2);
            ViewBag.mon2 = mon2;

            //---------------------

            var mon3 = await _reportService.GetReportsByMonth(3);
            ViewBag.mon3 = mon3;

            //--------------------

            var mon4 = await _reportService.GetReportsByMonth(4);
            ViewBag.mon4 = mon4;

            //--------------------

            var mon5 = await _reportService.GetReportsByMonth(5);
            ViewBag.mon5 = mon5;

            //--------------------

            var mon6 = await _reportService.GetReportsByMonth(6);
            ViewBag.mon6 = mon6;

            //--------------------

            var mon7 = await _reportService.GetReportsByMonth(7);
            ViewBag.mon7 = mon7;

            //--------------------

            var mon8 = await _reportService.GetReportsByMonth(8);
            ViewBag.mon8 = mon8;

            //--------------------

            var mon9 = await _reportService.GetReportsByMonth(9);
            ViewBag.mon9 = mon9;

            //--------------------

            var mon10 = await _reportService.GetReportsByMonth(10);
            ViewBag.mon10 = mon10;

            //--------------------

            var mon11 = await _reportService.GetReportsByMonth(11);
            ViewBag.mon11 = mon11;

            //--------------------

            var mon12 = await _reportService.GetReportsByMonth(12);
            ViewBag.mon12 = mon12;

            //--------------------
            var listReportAll = await _reportService.GetReports();
            ViewBag.listReportAll = listReportAll.OrderByDescending(y => y.CreatedDate).ToList();
            ViewBag.countItem = listReportAll.Count();
            return View();
        }

        public async Task<ActionResult> Index()
        {
            var listForm = await _fileService.GetFiles();
            ViewBag.listForm = listForm;
            var listClass = await _classService.GetClasses();
            ViewBag.listClass = listClass;
            var listReport = await _reportService.GetReports(5);
            ViewBag.listReport = listReport;

            return View();
        }
        public ActionResult Delete(int id)
        {
            var check = _fileService.DeleteFile(id);
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
        public ActionResult DeleteReport(int id)
        {
            var check = _reportService.DeleteReport(id);
            if(check)
            {
                SetAlert("Xoá thành công! :D", "success");
                return RedirectToAction("Statistics_Report");
            }    
            else
            {
                SetAlert("Xoá thất bại! D:", "error");
                return RedirectToAction("Statistics_Report");
            }    
        }

        public ActionResult AddFiles(FileVM model, string submit)
        {
            if (submit == "Thêm")
            {
                var check = _fileService.AddFile(model);
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
                var check = _fileService.UpdateFile(model);
                if(check)
                {
                    SetAlert("Cập nhật mẫu báo cáo thành công! :D", "success");
                    return RedirectToAction("Index");
                }    
                else
                {
                    SetAlert("Cập nhật mẫu báo cáo thất bại! D:", "error");
                    return RedirectToAction("Index");
                }    
            }
            else
            {
                var list = _fileService.GetFiles();
                return View("Index", list);
            }
        }

        public ActionResult SendReport(ReportVM model, string submit)
        {
            if (submit == "Gửi")
            {
                var check = _reportService.AddReport(model);
                if(check)
                {
                    SetAlert("Đã gửi báo cáo tháng thành công! :D", "success");
                    return RedirectToAction("Index");
                }    
                else
                {
                    SetAlert("Đã gửi báo cáo tháng thất bại! D:", "error");
                    return RedirectToAction("Index");
                }    
            }
            else if (submit == "Cập Nhật")
            {
                var check = _reportService.UpdateReport(model);
                SetAlert("Cập nhật mẫu báo cáo thất bại! D:", "error");
                return RedirectToAction("Index");
            }
            else
            {
                var list = _reportService.GetReports();
                return View("Index", list);
            }
        }
    }
}