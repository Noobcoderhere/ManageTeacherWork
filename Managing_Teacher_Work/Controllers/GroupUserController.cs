using Teacher_Manage_Core;
using Managing_Teacher_Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Managing_Teacher_Work.Controllers
{
    public class GroupUserController : BaseController
    {
        // GET: GroupUser
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public ActionResult Index()
        {
            List<GroupUser> listGroupUser = db.GroupUsers.ToList();
            ViewBag.listGroupUser = listGroupUser;

            return View();
        }
        //public ActionResult getList(int id)
        //{

        //    JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        //    var hs = db.GroupUser.SingleOrDefault(x => x.ID == id);
        //    var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
        //    return this.Json(result, JsonRequestBehavior.AllowGet);



        //}

        public ActionResult Add(GroupUser model, string submit)
        {
            if (submit == "Thêm")
            {


                isThemMoi = true;
                if (model != null)
                {
                    model.Name_GroupUser = model.Name_GroupUser.ToString().Trim();               
                    db.GroupUsers.Add(model);
                    db.SaveChanges();
                    model = null;
                }

                return RedirectToAction("Index");
            }
            else if (submit == "Cập Nhật")
            {
                isThemMoi = false;
                if (model != null)
                {
                    var list = db.GroupUsers.SingleOrDefault(x => x.ID == model.ID);
                    list.Name_GroupUser = model.Name_GroupUser.ToString().Trim();
                    db.SaveChanges();
                    model = null;
                }

                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name_GroupUser))
                {
                    List<GroupUser> list = GetData().Where(s => s.Name_GroupUser.Contains(model.Name_GroupUser)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<GroupUser> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<GroupUser> list = GetData().OrderBy(s => s.Name_GroupUser).ToList();
                return View("Index", list);
            }
        }
        public List<GroupUser> GetData()
        {
            return db.GroupUsers.ToList();


        }
    

    }
}