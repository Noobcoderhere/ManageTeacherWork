using Teacher_Manage_Core;
using Managing_Teacher_Web.Controllers;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Service.Service.WorkService;
using System;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class WorkController : BaseController
    {
        // GET: Work
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<ActionResult> Index()
        {
            var listWork = await _workService.GetWorks(false);
            ViewBag.listWork = listWork;
            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = _workService.GetWorkByID(id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Add(WorkVM model, string submit)
        {
            if (submit == "Thêm")
            {
                model.Status = "ChuaLam";
                model.CreatedDate = DateTime.Now;
                var check = _workService.AddWork(model);
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
                var check = _workService.Update(model);
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
                var list = await _workService.GetWorks();
                return View("Index", list.OrderBy(s => s.Name_Work).ToList());
            }
        }

        public ActionResult Delete(int id)
        {
            var check = _workService.Delete(id);
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