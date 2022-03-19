using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Managing_Teacher_Web.Controllers;
using Teacher_Manage_Service.Service.UserService;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Managing_Teacher_Web.Common;
using Teacher_Manage_Service.Service.RoleService;
using Teacher_Manage_Core.ViewModel.Person;

namespace Managing_Teacher_Work.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<ActionResult> Index()
        {
            var listUser = await _userService.GetUsers();
            ViewBag.listUser = listUser;
            var listRole = _roleService.GetRoles().ToList(); 
            ViewBag.listRole = listRole;

            return View();
        }
        public ActionResult GetData(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var role = _roleService.GetRoles();
            var userVM = _userService.GetUserByID(id);
            var result = JsonConvert.SerializeObject(userVM, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdate(UserVM user, string submit)
        {
            if (submit == "Thêm")
            {
                var check = _userService.AddUser(user);
                user = null;
                if (!check)
                {
                    SetAlert("Thêm thông tin không thành công! D:", "error");
                    return RedirectToAction("Index");
                }
                SetAlert("Thêm thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else if (submit == "Cập Nhật")
            {
                var check = await _userService.UpdateUser(user);
                user = null;
                if (!check)
                {
                    SetAlert("Cập nhật thông tin không thành công! D:", "error");
                    return RedirectToAction("Index");
                }
                SetAlert("Cập nhật thông tin thành công! :D", "success");
                return RedirectToAction("Index");
            }
            else
            {
                List<UserVM> list = (List<UserVM>)await GetUsers();
                return View("Index", list.OrderBy(x => x.UserName).ToList());
            }
        }
        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            return await _userService.GetUsers();
        }
        public ActionResult Delete(int id)
        {
            var check = _userService.DeleteUser(id);
            if(!check)
            {
                SetAlert("Xoá thất bại! D:", "error");
                return RedirectToAction("Index");
            }    
            SetAlert("Xoá thành công! :D", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/Login/Index");
        }

    }
}