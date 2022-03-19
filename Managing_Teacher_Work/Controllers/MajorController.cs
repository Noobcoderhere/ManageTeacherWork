using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Core;
using Teacher_Manage_Service.Service.MajorService;
using Teacher_Manage_Core.ViewModel;
using System.Threading.Tasks;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class MajorController : BaseController
    {
        // GET: Sciense
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public User currentUser;
        private readonly IMajorService _majorService;

        /// <summary>
        /// Kết nối bằng condition or api có sẵn trong mvc
        /// </summary>
        /// <returns></returns>
        ///
        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        public async Task<ActionResult> Index()
        {
            isThemMoi = true;
            ViewBag.Check = isThemMoi;
            var model = await _majorService.GetMajors();
            ViewBag.listSciense = model;          
            return View();
        }

        public async Task<ActionResult> GetMajorList()
        {
            var listMajor = await _majorService.GetMajors();
            ViewBag.ListMajor = listMajor.OrderByDescending(y => y.CreatedDate).ToList();
            return View();
        }

        public ActionResult getData(int id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = _majorService.GetMajorById(id);
            return this.Json(JsonConvert.SerializeObject(hs, Formatting.Indented, jss), JsonRequestBehavior.AllowGet);
        }
      /// <summary>
      /// Thêm và cập nhật dữ liệu bằng modal popup
      /// </summary>
      /// <param name="model"></param>
      /// <param name="submit"></param>
      /// <returns></returns>
        public async Task<ActionResult> Add(MajorVM model, string submit)
        {
            if (submit == "Thêm")
            {
                isThemMoi = true;
                var check = _majorService.AddMajor(model);
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
                isThemMoi = false;
                var check = _majorService.UpdateMajor(model);
                if(check)
                {
                    SetAlert("Cập nhật khoa thành công! :D", "success");
                    return RedirectToAction("Index");
                }    
                else
                {
                    SetAlert("Cập nhật khoa thất bại! D:", "error");
                    return RedirectToAction("Index");
                }    
            }
            else
            {
                var list = await _majorService.GetMajors();
                return View("Index", list.OrderBy(s => s.Name).ToList());
            }
        }

        /// <summary>
        /// Xoá item theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var check = _majorService.DeleteMajor(id);
            if(check)
            {
                SetAlert("Xoá thành công! :D", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Xoá thất bại! D:", "error");
            return RedirectToAction("Index");
        }
      
    }
}