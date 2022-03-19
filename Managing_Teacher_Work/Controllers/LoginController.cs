using System.Web.Mvc;
using Managing_Teacher_Web.Common;
using Managing_Teacher_Web.Models;
using Teacher_Manage_Service.Service.UserService;
using System.Threading.Tasks;
using Teacher_Manage_Service.Service.TeacherService;
using System.Collections.Generic;
using Teacher_Manage_Core.ViewModel.Person;
using System.Linq;

namespace Managing_Teacher_Work.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;

        public LoginController(IUserService userService, ITeacherService teacherService)
        {
            _userService = userService;
            _teacherService = teacherService;
        }
        // GET: Login
       public bool alertLogin = false;
        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = _userService.GetUserByUsername(model.UserName);
                    var teacher = (await _teacherService.GetTeachersByCondition(x => x.UserID == user.ID)).FirstOrDefault();
                    var userLogin = new UserLogin();
                    userLogin.UserName = user.UserName;
                    userLogin.ID = user.ID;
                    if(teacher != null)
                    {
                        userLogin.TeacherID = teacher.ID;
                    }    
                    userLogin.Name = user.Name;
                    userLogin.GroupID = user.GroupID;

                    Session.Add(CommonConstants.USER_SESSION, userLogin);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    Redirect("Login/Index");
                    ViewBag.Mes = "Sai mật khẩu hoặc tài khoản. Vui lòng kiểm tra lại!";
                }
                else if (result == -1)
                {
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    ViewBag.Mes = "Tài khoản đã bị khoá!";
                }
                else if (result == -2)
                {
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    ViewBag.Mes = "Sai mật khẩu hoặc tài khoản. Vui lòng kiểm tra lại!";
                }
                else
                {
                    alertLogin = true;
                    ViewBag.alertLogin = alertLogin;
                    ViewBag.Mes = "Đăng nhập không thành công";
                }
            }
            return View("Index");
        }
    }
}